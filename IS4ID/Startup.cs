﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IS4ID.Data;
using IS4ID.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IS4ID
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = "IS4ID";
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
                // options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            var builder = services.AddIdentityServer()
                            // use postgres for data
                .AddConfigurationStore(configDb => {
                    configDb.ConfigureDbContext = db => db.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })

                // use postgres for operational data (i.e. token)
                .AddOperationalStore(operationalDb => {
                    operationalDb.ConfigureDbContext = db => db.UseNpgsql(connectionString,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddAspNetIdentity<ApplicationUser>();

            // options =>
            // {
            //     options.Events.RaiseErrorEvents = true;
            //     options.Events.RaiseInformationEvents = true;
            //     options.Events.RaiseFailureEvents = true;
            //     options.Events.RaiseSuccessEvents = true;
            // })
            //     .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //     .AddInMemoryApiResources(Config.GetApis())
            //     .AddInMemoryClients(Config.GetClients())

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "708996912208-9m4dkjb5hscn7cjrn5u0r4tbgkbj1fko.apps.googleusercontent.com";
                    options.ClientSecret = "wdfPY6t8H8cecgjlxud__4Gh";
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            InitializaDatabase(app);
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentityServer();
            app.UseMvcWithDefaultRoute();
        }

        private void InitializaDatabase(IApplicationBuilder app){
            // Using services scope
            var serviceScope = app.ApplicationServices.GetServices<IServiceScopeFactory>();
            // .CreateScope();

                // using PersistedGrant DB (could be redis)
                // if doesnt exist, run migration 
                // var persistedGrantDbContext = serviceScope.ServiceProvider
                //     .GetRequiredService<PersistedGrantDbContext>();
                // persistedGrantDbContext.Database.Migrate();

        //         // using IS4 Config DB
        //         // if doesnt exist, run migration 
        //         var configDbContext = serviceScope.ServiceProvider
        //             .GetRequiredService<ConfigurationDbContext>();
        //         configDbContext.Database.Migrate();

        //         // Generating the records prior to the Clients, IdentityResources, and 
        //         // API Resourcess that are defined in Config Class
        //         if (!configDbContext.Clients.Any()){
        //             foreach (var client in Config.GetClients())
        //             {
        //                 configDbContext.Clients.Add(client.ToEntity());
        //             }
        //             configDbContext.SaveChanges();
        //         }

        //         if (!configDbContext.Clients.Any()){
        //             foreach(var res in Config.GetIdentityResources())
        //             {
        //                 configDbContext.IdentityResources.Add(res.ToEntity());
        //             }
        //             configDbContext.SaveChanges();
        //         }

        //         if (!configDbContext.ApiResources.Any()) {
        //             foreach(var api in Config.GetApis())
        //             {
        //                 configDbContext.ApiResources.Add(api.ToEntity());
        //             }
        //             configDbContext.SaveChanges();
        //         }


        }   
    }
}
