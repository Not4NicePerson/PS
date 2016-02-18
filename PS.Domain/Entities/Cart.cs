using System.Collections.Generic;
using System.Linq;
using PS.Domain.Entities.Db;

namespace PS.Domain.Entities
{
	public class Cart
	{
		private readonly List<CartLine> _lines = new List<CartLine>();

		public void Add(Product prod, int quantity)
		{
			CartLine line = _lines.FirstOrDefault(x => x.Product.Id == prod.Id);
			if (line == null)
			{
				_lines.Add(new CartLine
				{
					Product = prod,
					Quantity = quantity
				});
			}
			else
			{
				line.Quantity += quantity;
			}
		}

		public void RemoveLine(Product prod)
		{
			_lines.RemoveAll(x => x.Product.Id == prod.Id);
		}

		public decimal ComputeTotalValue()
		{
			return _lines.Sum(x => x.Quantity * x.Product.Price);
		}

		public void Clear()
		{
			_lines.Clear();
		}

		public IEnumerable<CartLine> Lines
		{
			get { return _lines.AsEnumerable(); }
		} 
	}

	public class CartLine
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
	}

}
