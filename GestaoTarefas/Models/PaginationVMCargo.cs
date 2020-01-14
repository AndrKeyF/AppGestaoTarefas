using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoTarefas.Models
{
    public class PaginationVMCargo<T> : List<T>
    {
        
        

        public IEnumerable<Cargo> Cargos { get; set; }
      






        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FirstPageShow { get; set; }
        public int LastPageShow { get; set; }
       // private int NUMBER_PAGES_BEFORE_AND_AFTER;

        public PaginationVMCargo(List<T> items, int count, int page, int NUMBER_PAGES_BEFORE_AND_AFTER, decimal NUMBER_CARG_PER_PAGE)
        {
            CurrentPage = page;
            
            FirstPageShow = Math.Max(1, page - NUMBER_PAGES_BEFORE_AND_AFTER);
            TotalPages = (int)Math.Ceiling(count / NUMBER_CARG_PER_PAGE);

            this.AddRange(items);
        }

         
        public static async Task<PaginationVMCargo<T>> CreateAsync(IQueryable<T> source, int page, int CARG_PER_PAGE, int NUMBER_PAGES_BEFORE_AND_AFTER)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * CARG_PER_PAGE).Take(CARG_PER_PAGE).ToListAsync();


            return new PaginationVMCargo<T>(items, count, page, CARG_PER_PAGE, NUMBER_PAGES_BEFORE_AND_AFTER);
        }


    }
}
