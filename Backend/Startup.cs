using System;
using Rest_api_Assignments;
using Rest_api_Assignments.Repository;
using Rest_api_Assignments.Services;

namespace Rest_api_assignments
{
	public class Startup
	{
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
	
		public void ConfigureServices(IServiceCollection services)
		{

			services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
			services.AddScoped<IActorService, ActorService>();
			services.AddScoped<IProducerService, ProducerService>();
			services.AddScoped<IGenreService, GenreService>();
			services.AddScoped<IReviewService, ReviewService>();
			services.AddScoped<IMovieService, MovieService>();
			services.AddScoped<IActorRepository, ActorRepository>();
			services.AddScoped<IProducerRepository, ProducerRepository>();
			services.AddScoped<IGenreRepository, GenreRespository>();
			services.AddScoped<IReviewRepository, ReviewRepository>();
			services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:8080")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });
            services.AddControllers();


			

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

