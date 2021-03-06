﻿using Mendo.UWP.Common;
using MyShelf.API.Services;
using MyShelf.API.XML;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Html;

namespace MyShelf.ViewModels
{
    public class AuthorViewModel : ViewModelBase
    {
        public string Id { get { return Get<string>(); } set { Set(value); } }
        public string ImageUrl  { get { return Get<string>(); } set { Set(value); } }
        public string Name  { get { return Get<string>(); } set { Set(value); } }
        public string Url  { get { return Get<string>(); } set { Set(value); } }
        public string Hometown  { get { return Get<string>(); } set { Set(value); } }
        public string BornAt  { get { return Get<string>(); } set { Set(value); } }
        public string DiedAt { get { return Get<string>(); } set { Set(value); } }
        public string Genre  { get { return Get<string>(); } set { Set(value); } }
        public string Gender  { get { return Get<string>(); } set { Set(value); } }
        public string Link  { get { return Get<string>(); } set { Set(value); } }
        public string About  { get { return Get<string>(); } set { Set(value); } }
        public string Influences  { get { return Get<string>(); } set { Set(value); } }
        public string Rating  { get { return Get<string>(); } set { Set(value); } }
        public string WorksCount  { get { return Get<string>(); } set { Set(value); } }
        public ObservableCollection<BookViewModel> AuthorBooks { get; private set; } = new ObservableCollection<BookViewModel>();

        public bool IsLoading { get { return GetV(false); } set { Set(value); } }

        public AuthorViewModel(Author author)
        {
            PopulateAuthorDetails(author);

            GetAuthorBooks(author.Id);            
        }

        public AuthorViewModel(string id)
        {
            GetAuthorData(id);
        }

        private async Task GetAuthorData(string id)
        {
            IsLoading = true;
            var author = await AuthorService.Instance.GetAuthorInfo(id);

            PopulateAuthorDetails(author);
            IsLoading = false;
            GetAuthorBooks(id);
        }

        private async Task GetAuthorBooks(string id)
        {
            AuthorBooks.Clear();
            var books = await AuthorService.Instance.GetAuthorBooks(id);
            foreach (var book in books.Book)
            {
                AuthorBooks.Add(new BookViewModel(book));
            }
        }

        private void PopulateAuthorDetails(Author author)
        {
            Id = author.Id;

            ImageUrl = author.ImageUrl;
            Name = author.Name;
            Url = author.Url;
            Hometown = author.Hometown;
            BornAt = author.BornAt;
            DiedAt = author.DiedAt;
            Genre = string.Join(", ", new[] { author.Genre1, author.Genre2, author.Genre3 });
            Gender = author.Gender;
            Link = author.Link;
            About = HtmlUtilities.ConvertToText(author.About);
            Influences = HtmlUtilities.ConvertToText(author.Influences);
            Rating = author.AverageRating;
            WorksCount = $"{author.WorksCount} Works";
        }
    }
}
