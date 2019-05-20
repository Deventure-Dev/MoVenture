using AutoMapper;
using Moventure.BusinessLogic.Helpers;
using Moventure.DataLayer.Models;
using Moventure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using UpWorky.DataLayer.Repositories;

namespace Moventure.BusinessLogic.Repo
{
    public class UserRepo : BaseSinglePkRepository<Users>
    {
        private readonly IMapper mMapper;

        public static List<MinifiedMovie> MinifiedMovieList = new List<MinifiedMovie>();
        public static List<Movie> FullMovieList = new List<Movie>();
        //public static List<MinifiedMovie> movieList;

        public static List<CategoryModel> CategoryList = new List<CategoryModel>();

        public static Tag tag1, tag2;

        public UserRepo(IMapper mapper = null)
        {
            mMapper = mapper;
            var mapper2 = ServiceProviderHelper.ServiceProvider.GetService(typeof(IMapper));
        }

        public static void Init()
        {
            MinifiedMovieList = new List<MinifiedMovie>();
            var movie1 = new MinifiedMovie();
            movie1.Id = Guid.Parse("95f90c86-2d30-42ff-bd0c-fadac0f26a14");
            movie1.Title = "Mr. Nobody";
            movie1.Rating = 5;
            movie1.PictureUrl = "https://m.media-amazon.com/images/M/MV5BMTg4ODkzMDQ3Nl5BMl5BanBnXkFtZTgwNTEwMTkxMDE@._V1_.jpg";

            var category1 = new CategoryModel();
            category1.Id = Guid.Parse("a61ffbc0-4bc1-46f5-b1d7-19077911fe29");
            category1.Name = "Action";
            category1.SavedAt = new DateTime();
            category1.MovieList.Add(movie1);
            MinifiedMovieList.Add(movie1);
            //movie1.MainCategory = category1;
            CategoryList.Add(category1);

            var movie2 = new MinifiedMovie();
            movie2.Id = Guid.Parse("3d950a14-009a-4968-abf9-e940acf19be6");
            movie2.Title = "Hary Potter";
            movie2.Rating = 4;
            movie2.PictureUrl = "https://timedotcom.files.wordpress.com/2014/07/301386_full1.jpg";

            var category2 = new CategoryModel();
            category2.Id = Guid.Parse("4031ea58-b7b9-4dee-8e01-32b92d0e6367");
            category2.Name = "Drama";
            category2.SavedAt = new DateTime();
            category2.MovieList.Add(movie2);
            MinifiedMovieList.Add(movie2);
            //movie2.MainCategory = category2;
            CategoryList.Add(category2);

            tag1 = new Tag();
            tag1.Id = Guid.Parse("9dbb38f3-b16f-4579-8b65-d3f5269484e3");
            tag1.Name = "sci fi";
            var tagsList = new List<Tag>();
            tagsList.Add(tag1);
            movie1.Tags = tagsList.ToList();

            tag2 = new Tag();
            tag2.Id = Guid.Parse("4031ea58-b7b9-4dee-8e01-32b92d0e6367");
            tag2.Name = "thriller";
            tagsList.Add(tag2);
            movie2.Tags = tagsList.ToList();

            //FullMovieList = new List<Movie>();
            //var actorsList = new List<ActorModel>();
            //var commentsList = new List<Comment>();

            //var fullMovie1 = new Movie();
            //var actor1 = new ActorModel();
            //actor1.Id = Guid.Parse("cce76d9c-165a-4212-a6b9-f43a4704abf3");
            //actor1.FirstName = "Brad";
            //actor1
            
        }

        public UserData GetUserData(string email)
        {
            var fetchedUser = GetSingle(user => user.Email == email);
            //get categories
            return new UserData
            {
                //User = mMapper.Map<User>(fetchedUser),
                User = null,
                Categories = CategoryList

            };
        }

    }
}
