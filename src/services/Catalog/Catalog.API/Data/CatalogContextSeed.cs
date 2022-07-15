using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            var existProduct = productCollection.Find(c => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id="62d16d0368d7eab867c5e286",
                    Name="Samsung S20 fe",
                    Category="Smart Phone",
                    Price=450,
                    ImageFile="https://www.google.com/imgres?imgurl=http%3A%2F%2Fimg.panzerprotect.cz%2Fimages%2FEdge-to-Edge%2520skla%2F7243_PHONE_LOGO.jpg%3Ftid%3D19&imgrefurl=http%3A%2F%2Fwww.panzerprotect.cz%2Fpanzerglass-edge-to-edge-antibacterial-pro-samsung-galaxy-s20-fe-cerne&tbnid=T8fqJpIZmeyvFM&vet=12ahUKEwig99Deg_v4AhWph_0HHYQqDzEQMygLegUIARCOAg..i&docid=H3aRNdQscHArHM&w=1200&h=1200&itg=1&q=image%20samsung%20fe&hl=en&ved=2ahUKEwig99Deg_v4AhWph_0HHYQqDzEQMygLegUIARCOAg"
                },
                new Product
                {
                    Id="62d17009a7755750f294d764",
                    Name="iphone 13",
                    Category="Smart Phone",
                    Price=770,
                    ImageFile="https://www.google.com/imgres?imgurl=https%3A%2F%2Fstore.storeimages.cdn-apple.com%2F4668%2Fas-images.apple.com%2Fis%2Fiphone-13-pink-select-2021%3Fwid%3D470%26hei%3D556%26fmt%3Djpeg%26qlt%3D95%26.v%3D1645572315935&imgrefurl=https%3A%2F%2Fwww.apple.com%2Fnl%2Fshop%2Fbuy-iphone%2Fiphone-13%2F6%2C1%25E2%2580%2591inch-display-128gb-roze&tbnid=HD7ywMZrSaZgMM&vet=12ahUKEwjwg7fXhPv4AhWE_bsIHZr-ATUQ94IIKAN6BQgBEKgD..i&docid=yhwX7edTWsRhZM&w=470&h=556&q=iphone%2013&ved=2ahUKEwjwg7fXhPv4AhWE_bsIHZr-ATUQ94IIKAN6BQgBEKgD"
                },
                new Product
                {
                    Id="62d1717797810554f03d4ea2",
                    Name="iphone 13 pro Max",
                    Category="Smart Phone",
                    Price=1250,
                    ImageFile="https://www.google.com/imgres?imgurl=https%3A%2F%2Fstore.storeimages.cdn-apple.com%2F4668%2Fas-images.apple.com%2Fis%2Fiphone-13-pro-blue-select%3Fwid%3D470%26hei%3D556%26fmt%3Djpeg%26qlt%3D95%26.v%3D1645552346275&imgrefurl=https%3A%2F%2Fwww.apple.com%2Fnl%2Fshop%2Fbuy-iphone%2Fiphone-13-pro%2F6%2C1%25E2%2580%2591inch-display-128gb-sierra-blue&tbnid=RL9XGqEswGNz6M&vet=12ahUKEwjwg7fXhPv4AhWE_bsIHZr-ATUQMygCegUIARClAw..i&docid=43jCOwOuBfgmFM&w=470&h=556&q=iphone%2013&ved=2ahUKEwjwg7fXhPv4AhWE_bsIHZr-ATUQMygCegUIARClAw"
                }
            };
        }
    }
}
