﻿namespace Web_API.Handlers.Empleados.DTOs
{
    public class PaginatedResponseDTO<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalItems / (double)PageSize);

        public PaginatedResponseDTO(List<T> items, int totalItems, int currentPage, int pageSize)
        {
            Items = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            PageSize = pageSize;
        }
    }
}