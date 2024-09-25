using MicromarinCase.Repositories;
using MicromarinCase.Repositories.Products;
using MicromarinCase.Services.Products.Create;
using MicromarinCase.Services.Products.Update;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MicromarinCase.Services.Products
{
    public class ProductService(IProductRepository productRepository,IUnitOfWork unitOfWork,IMapper mapper):IProductService
    {
        public async Task<ServiceResult<ProductWithOrderDetailDto>> GetProductWithOrderDetailsAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult<ProductWithOrderDetailDto?>.Fail("ürün bulunamadi", HttpStatusCode.NotFound);

            var productWithOrders = await productRepository.GetProdcutWithOrderDetailsAsync(id);
            var productWithOrdersAsDto = mapper.Map<ProductWithOrderDetailDto>(productWithOrders);
            return ServiceResult<ProductWithOrderDetailDto>.Success(productWithOrdersAsDto);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllListAsync()
        {
            var products=await productRepository.GetAll().ToListAsync();

            var productsAsDto =mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productsAsDto);
        } 
  
        public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
        {
            var product =await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult<ProductDto?>.Fail("Product not found", HttpStatusCode.NotFound);

            var productAsDto = mapper.Map<ProductDto>(product);


            return ServiceResult<ProductDto>.Success(productAsDto)!;
        }

        public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
        {
            var anyProduct = await productRepository.Where(x => x.Name == request.Name).AnyAsync();
            if (anyProduct)
                return ServiceResult<CreateProductResponse>.Fail("Ürün ismi veritabanında bulunmaktadır");

            var product =mapper.Map<Product>(request);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),$"api/products/{product.Id}");
        }

        public async Task<ServiceResult> UpdateAsync(int id,UpdateProductRequest request)
        {
            var product=await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);

            var isProductNameExits = await productRepository.Where(x => x.Name == request.Name && x.Id!=product.Id).AnyAsync();
            if (isProductNameExits)
                return ServiceResult.Fail("Güncellenecek ürün  bulunmaktadır");

            product = mapper.Map(request, product);

            productRepository.Update(product);
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);

            product.IsDeleted=true;
            await unitOfWork.SaveChangeAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);

        }

    }
}
