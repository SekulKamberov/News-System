//namespace NewsSystem.Domain.ArticleCreation.Models.Articles
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    using Common;  

//    internal class ArticleData : IInitialData
//    {
//        public Type EntityType => typeof(Article);

//        private static readonly IEnumerable<Category> AllowedCategories
//            = new CategoryData().GetData().Cast<Category>();

//        public IEnumerable<object> GetData()
//            => new List<Article>
//            {
//                new Article(
//                    "Cats title",
//                    "When Ian Patella's cat got stuck in a tree late last week, his family's local contractor came to the rescue.",
//                    AllowedCategories.First(),
//                    "https://cdn.pixabay.com/photo/2020/04/27/09/21/cat-5098930_960_720.jpg",
//                    1),
//                new Article(
//                    "The Super cat",
//                    "This is the most difficult action game in the world. It is full of infinite challenge and traps, made for only the most experienced gamers.",
//                    AllowedCategories.Last(),
//                    "https://cdn.pixabay.com/photo/2014/03/29/09/17/cat-300572_960_720.jpg",
//                    1),
//                new Article(
//                    "How coronavirus",
//                    "Since the outset of the coronavirus pandemic, the potential role of animals in catching and spreading the disease has been closely examined by scientists. This is because the virus that causes Covid-19 belongs to the family of coronaviruses that cause disease in a variety of mammals.",
//                    new Category ("World", "fdsfsfdcxcxcxcxcxcxcfdfdfdf"),
//                    "https://cdn.pixabay.com/photo/2014/11/30/14/11/kitty-551554_960_720.jpg",
//                    1),
//                new Article(
//                    "International Cat Day",
//                    "The 8 August marks International Cat Day, an annual event that has been celebrated since 2002. It was originally created by the International Fund for Animal Welfare which works to raise awareness for felines, from big cats to domestic pets, and educate people on how to look after and protect them.",
//                    new Category ("Political", "fdsfsfdfxcxcxcxcxcxcxcxcxdfdfdf"),
//                    "https://cdn.pixabay.com/photo/2016/02/10/16/37/cat-1192026_960_720.jpg",
//                    1),
//                new Article(
//                    "International Cat Day",
//                    "The 8 August marks International Cat Day, an annual event that has been celebrated since 2002. It was originally created by the International Fund for Animal Welfare which works to raise awareness for felines, from big cats to domestic pets, and educate people on how to look after and protect them.",
//                    new Category ("Political", "fdsfsfdfxcxcxcxcxcxcxcxcxdfdfdf"),
//                    "https://cdn.pixabay.com/photo/2013/05/30/18/21/tabby-114782_960_720.jpg",
//                    1),
//               new Article(
//                    "International Cat Day",
//                    "The 8 August marks International Cat Day, an annual event that has been celebrated since 2002. It was originally created by the International Fund for Animal Welfare which works to raise awareness for felines, from big cats to domestic pets, and educate people on how to look after and protect them.",
//                    new Category ("Political", "fdsfsfdfxcxcxcxcxcxcxcxcxdfdfdf"),
//                    "https://cdn.pixabay.com/photo/2016/03/28/12/35/cat-1285634_960_720.png",
//                    1),
//               new Article(
//                    "International Cat Day",
//                    "The 8 August marks International Cat Day, an annual event that has been celebrated since 2002. It was originally created by the International Fund for Animal Welfare which works to raise awareness for felines, from big cats to domestic pets, and educate people on how to look after and protect them.",
//                    new Category ("Political", "fdsfsfdfxcxcxcxcxcxcxcxcxdfdfdf"),
//                    "https://cdn.pixabay.com/photo/2019/06/16/09/43/cat-4277400_960_720.jpg",
//                    1),
//            };
//    }
//}
