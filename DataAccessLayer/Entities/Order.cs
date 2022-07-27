namespace DataAccessLayer.Entities
{
    /// <summary>
    /// Модель Заказа
    /// </summary>
    public record class Order : BaseEntity
    {
        /// <summary>
        /// Емейл пользователя
        /// </summary>
        public string? EmailCustomer { get; init; }
        /// <summary>
        /// Код товара
        /// </summary>
        public int Atricle { get; init; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string? NameProduct { get; init; } 
    }
}
