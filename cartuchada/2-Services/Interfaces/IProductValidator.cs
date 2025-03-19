namespace _2_Services.Interfaces
{
    public interface IProductValidator<TProduct>
    {
        public List<string> Errors { get; set; }
        Task<bool> ValidateProductAsync(TProduct product);
    }
}
