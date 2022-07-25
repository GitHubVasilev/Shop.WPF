namespace BusinessLogicLayer.DataTransferObject.Entitys
{
    /// <summary>
    /// класс для передачи данных о Заказе
    /// </summary>
    public record class OrderDTO : BaseEntityDTO
    {
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
