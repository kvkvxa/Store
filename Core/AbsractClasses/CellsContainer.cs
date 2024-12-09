using System;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public abstract class CellsContainer
    {
        private readonly List<Cell> _cells = new List<Cell>();

        public Cell GetCellByName(string name)
        {
            return _cells.FirstOrDefault(cell => cell.Good.Name == name);
        }

        public virtual void Add(Good good, int quantity)
        {
            IModifableCell existingCell = _cells.FirstOrDefault(cellToFind => cellToFind.Good.Name == good.Name);

            if (existingCell != null)
            {
                existingCell.Merge(quantity);
            }
            else
            {
                _cells.Add(new Cell(good, quantity));
            }
        }

        public IReadOnlyList<IReadonlyCell> GetCells()
        {
            return _cells.ToList();
        }

        public void ShowGoods()
        {
            _cells.ForEach(cell =>
            {
                Console.WriteLine($"{cell.Good.Name} - {cell.Quantity}");
            });
        }
    }
}