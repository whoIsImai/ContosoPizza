using ContosoPizza.Model;

namespace ContosoPizza.Service
{
    public class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) => Pizzas.Find(p => p.Id == id);

        public static void Add(Pizza p)
        {
            p.Id = nextId++;
            Pizzas.Add(p);
        }
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null) return;
            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            int index = Pizzas.FindIndex(p=> p.Id == pizza.Id);
            if (index == -1) return;

            Pizzas[index] = pizza;
        }
    }
}
