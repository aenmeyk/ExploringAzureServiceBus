using System;

namespace Common
{
    public class QuoteRequest
    {
        public int QuoteId { get; set; }
        public ConsoleColor Product { get; set; }

        public override string ToString()
        {
            return string.Format("QuoteId: {0}, Product {1}", QuoteId, Product);
        }
    }
}