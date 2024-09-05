using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoBDePOO.Modelos;

internal class Despesa
{
    public int IdDespesa { get; set; }
    public decimal Valor {  get; set; }
    public DateOnly DataVencimento { get; set; }
    public DateOnly DataPagamento { get; set; }
    public bool Situacao { get; set; }
    public int Fk_Id_Caixa {  get; set; }
    public int Fk_Id_Fornecedor { get; set; }
         
}
