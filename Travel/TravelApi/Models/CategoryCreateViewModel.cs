﻿namespace TravelApi.Models
{
    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
    }
    public class CategoryCreateViewModel
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
    public class CategoryEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public string Image { get; set; }
        public IFormFile ImageUpload { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}

