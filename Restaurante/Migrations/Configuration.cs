namespace WebRestaurante.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebRestaurante.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebRestaurante.Models.dbWebRestaurante>
    {
        public Configuration()
        {
           AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebRestaurante.Models.dbWebRestaurante context)
        {
            var restaurante = new List<Restaurante>
            {
                new Restaurante { ID = 1, Nome = "Restaurante 1", Ativo = true },
                new Restaurante { ID = 2, Nome = "Restaurante 2", Ativo = true },
                new Restaurante { ID = 3, Nome = "Restaurante 3", Ativo = true },
                new Restaurante { ID = 4, Nome = "Restaurante 4", Ativo = false },
                new Restaurante { ID = 5, Nome = "Restaurante 5", Ativo = true },
                new Restaurante { ID = 6, Nome = "Restaurante 6", Ativo = false }
            };
            restaurante.ForEach(r => context.Restaurantes.AddOrUpdate(p => p.Nome, r));
            context.SaveChanges();

            var pratos = new List<Prato>
            {
                new Prato { ID = 1, Nome = "Prato 1", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 1").ID, Preco = 10, Ativo = true },
                new Prato { ID = 2, Nome = "Prato 2", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 2").ID, Preco = 10, Ativo = true },
                new Prato { ID = 3, Nome = "Prato 3", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 3").ID, Preco = 10, Ativo = true },
                new Prato { ID = 4, Nome = "Prato 4", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 4").ID, Preco = 10, Ativo = true },
                new Prato { ID = 5, Nome = "Prato 5", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 5").ID, Preco = 10, Ativo = true },
                new Prato { ID = 6, Nome = "Prato 6", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 1").ID, Preco = 10, Ativo = true },
                new Prato { ID = 7, Nome = "Prato 7", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 2").ID, Preco = 10, Ativo = true },
                new Prato { ID = 8, Nome = "Prato 8", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 3").ID, Preco = 10, Ativo = true },
                new Prato { ID = 9, Nome = "Prato 9", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 4").ID, Preco = 10, Ativo = true },
                new Prato { ID = 10, Nome = "Prato 10", RestauranteID = restaurante.Single(r => r.Nome == "Restaurante 5").ID, Preco = 10, Ativo = true }
            };
            pratos.ForEach(r => context.Pratos.AddOrUpdate(p => p.Nome, r));
            context.SaveChanges();
        }
    }
}
