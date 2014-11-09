using System;

namespace Common
{
    public class QuoteResponse
    {
        public QuoteResponse() { }

        public QuoteResponse(QuoteRequest quoteRequest)
        {
            QuoteId = quoteRequest.QuoteId;
            Product = quoteRequest.Product;
        }

        public int QuoteId { get; set; }
        public ConsoleColor Product { get; set; }
        public string Vendor { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return string.Format("QuoteId: {0}, Product {1}, Vendor {2}, Price {3}", QuoteId, Product, Vendor, Price);
        }
    }
}