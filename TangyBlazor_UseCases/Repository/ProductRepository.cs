using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TangyBlazor_DataAccess.Data;
using TangyBlazor_UseCases.Mapper;
using TangyBlazor_UseCases.Repository.IRepository;

namespace TangyBlazor_UseCases.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDBContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO ObjDTO)
        {
            var Product = _mapper.Map<ProductDTO, Product>(ObjDTO);
            await _db.products.AddAsync(Product);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(Product);    

        }

        public async Task<bool> Delete(int id)
        {
            var Product = await _db.categories.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(Product != null)
            {
                _db.categories.Remove(Product);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ProductDTO> Get(int id)
        {
            var Product = await _db.products.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(Product != null)
            {
                return _mapper.Map<Product, ProductDTO>(Product);
            }
            return new ProductDTO();
        }

        public async  Task<IEnumerable<ProductDTO>> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDTO>>(_db.products);

            }
            catch(Exception ex)
            {
                var x = ex.Message;
                return Enumerable.Empty<ProductDTO>();
            }
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var ProductFromDb = await _db.products.Where(u => u.Id == objDTO.Id).FirstOrDefaultAsync();
            if(ProductFromDb != null)
            {
                ProductFromDb.Name = objDTO.Name;
                ProductFromDb.Desciption = objDTO.Desciption;
                ProductFromDb.ImageUrl = objDTO.ImageUrl;
                ProductFromDb.CategoryId = objDTO.CategoryId;
                ProductFromDb.Color = objDTO.Color;
                ProductFromDb.ShopFavorites = objDTO.ShopFavorites;
                ProductFromDb.CustomerFavorites = objDTO.CustomerFavorites;
                _db.products.Update(ProductFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product,ProductDTO>(ProductFromDb);
            }
            return objDTO;
        }
    }
}
