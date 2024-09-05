



using Mysqlx.Prepare;
using System;
using System.Net.Http.Headers;
using TrabalhoBDePOO.dao;
using TrabalhoBDePOO.Modelos;

int op = 0;

do
{
    Console.ForegroundColor = ConsoleColor.DarkGray;
    
    Console.WriteLine(@"
    ██████╗░███████╗░██████╗██████╗░███████╗░██████╗░█████╗░░██████╗  ░█████╗░██████╗░██╗░░░██╗██████╗░
    ██╔══██╗██╔════╝██╔════╝██╔══██╗██╔════╝██╔════╝██╔══██╗██╔════╝  ██╔══██╗██╔══██╗██║░░░██║██╔══██╗
    ██║░░██║█████╗░░╚█████╗░██████╔╝█████╗░░╚█████╗░███████║╚█████╗░  ██║░░╚═╝██████╔╝██║░░░██║██║░░██║
    ██║░░██║██╔══╝░░░╚═══██╗██╔═══╝░██╔══╝░░░╚═══██╗██╔══██║░╚═══██╗  ██║░░██╗██╔══██╗██║░░░██║██║░░██║
    ██████╔╝███████╗██████╔╝██║░░░░░███████╗██████╔╝██║░░██║██████╔╝  ╚█████╔╝██║░░██║╚██████╔╝██████╔╝
    ╚═════╝░╚══════╝╚═════╝░╚═╝░░░░░╚══════╝╚═════╝░╚═╝░░╚═╝╚═════╝░  ░╚════╝░╚═╝░░╚═╝░╚═════╝░╚═════╝░
    ");

    Console.ForegroundColor = ConsoleColor.Gray;
    
    Console.WriteLine("");
    
    Console.WriteLine("QUAL FUNÇÃO VOCÊ DESEJA?");
    Console.WriteLine("");
    Console.WriteLine("[1]CADASTRAR UMA DESPESA.");
    Console.WriteLine("[2]VISUALIZAR UMA DESPESA.");
    Console.WriteLine("[3]ALTERAR UMA DESPESA.");
    Console.WriteLine("[4]DELETAR UMA DESPESA.");
    Console.WriteLine("[5]LISTAR TODAS AS DESPESAS.");
    Console.WriteLine("[0]SAIR");
    Console.WriteLine("");
    op = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("");

    switch (op)
    {
        case 1:

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;


            Despesa despesa = new Despesa();
            Console.WriteLine("Digite o ID da nova Despesa:");
            despesa.IdDespesa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Digite o Valor da nova Despesa:");
            despesa.Valor = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Digite a Data de Vencimento da nova Despesa");
            Console.WriteLine("");
            Console.WriteLine("Dia:");
            int dia = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Mês:");
            int mes = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Ano:");
            int ano = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            DateOnly date = new DateOnly(ano,mes,dia);

            despesa.DataVencimento = date;

            Console.WriteLine("Digite a Data de Pagamento da nova Despesa");
            Console.WriteLine("");
            Console.WriteLine("Dia:");
            int dia2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Mês:");
            int mes2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Ano:");
            int ano2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            DateOnly date2 = new DateOnly(ano2, mes2, dia2);

            despesa.DataPagamento = date2;

            Console.WriteLine("Digite a situacão da nova Despesa:");
            Console.WriteLine("[1] Ativa");
            Console.WriteLine("[2] Inativaa");
            int situacao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            if (situacao == 1)
            {
                despesa.Situacao = true;
            }
            else
            {
                despesa.Situacao= false;
            }

            Console.WriteLine("Digite o Caixa ligado a nova Despesa:");
            Console.WriteLine("[1] Caixa principal");
            Console.WriteLine("[2] Caixa segundário");
            
            despesa.Fk_Id_Caixa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite o Fornecedor ligado a nova Despesa");
            Console.WriteLine("[1] Cascões da Flor");
            Console.WriteLine("[2] Fábrica Rondo Sorveter");
            Console.WriteLine("[3] Don Coberturas");
            Console.WriteLine("[4] Coca-Cola");
            despesa.Fk_Id_Fornecedor = Convert.ToInt32(Console.ReadLine());

            DespesaDAO.Insert(despesa);

            break;

        case 2:

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            List<Despesa> despesasRead = new List<Despesa>();
            Despesa despesa3 = new Despesa();

            Console.WriteLine("Digite o ID da Despesa a ser visualizada:");
            despesa3.IdDespesa = Convert.ToInt32(Console.ReadLine());

            despesasRead.Add(DespesaDAO.Read(despesa3));
            

            foreach (var d in despesasRead)
            {
                Console.WriteLine("Dados da despesa de ID " + d.IdDespesa + ".");
                Console.WriteLine("Valor: R$" + d.Valor);
                Console.WriteLine("Data Vencimento: " + d.DataVencimento);
                Console.WriteLine("Data Pagamento: " + d.DataPagamento);
                if (d.Situacao == true)
                {
                    Console.WriteLine("Situacão: Ativa");
                }
                else
                {
                    Console.WriteLine("Situacão: Inativa");
                }
                Console.WriteLine("ID do Caixa vinculado: " + d.Fk_Id_Caixa);
                Console.WriteLine("ID do Fornecedor vinculado: " + d.Fk_Id_Fornecedor);
                Console.WriteLine("");
            }

            break;

        case 3:

            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.DarkYellow;


            Despesa despesa4 = new Despesa();

            Console.WriteLine("Digite o ID da Despesa a ser alterada:");
            despesa4.IdDespesa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("OBS: Os dados que não quiser alterar, apenas digite eles novamente");
            Console.WriteLine("");
            Console.WriteLine("Digite o novo Valor:");
            despesa4.Valor = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite a nova Data de Vencimento.");

            Console.WriteLine("Dia:");
            int dia3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Mês:");
            int mes3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Ano:");
            int ano3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            DateOnly date3 = new DateOnly(ano3, mes3,dia3);

            despesa4.DataVencimento = date3;
                

            Console.WriteLine("Digite a nova Data de Pagamento.");

            Console.WriteLine("Dia:");
            int dia4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Mês:");
            int mes4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("Ano:");
            int ano4 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            DateOnly date4 = new DateOnly(ano4, mes4, dia4);

            despesa4.DataPagamento = date4;

            Console.WriteLine("Digite a nova Situação:");
            Console.WriteLine("[1] Ativa");
            Console.WriteLine("[2] Inativaa");
            int situacao2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            if (situacao2 == 1)
            {
                despesa4.Situacao = true;
            }
            else
            {
                despesa4.Situacao = false;
            }

            Console.WriteLine("Digite o novo Caixa ligado a Despesa:");
            Console.WriteLine("[1] Caixa principal");
            Console.WriteLine("[2] Caixa segundário");

            despesa4.Fk_Id_Caixa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            Console.WriteLine("Digite o novo Fornecedor ligado a Despesa");
            Console.WriteLine("[1] Cascões da Flor");
            Console.WriteLine("[2] Coca-Cola");
            Console.WriteLine("[3] Don Coberturas");
            Console.WriteLine("[4] Fábrica Rondo Sorvetes");
            despesa4.Fk_Id_Fornecedor = Convert.ToInt32(Console.ReadLine());

            DespesaDAO.Update(despesa4);

            break;

        case 4:

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;


            Despesa despesa2 = new Despesa();

            Console.WriteLine("Digite o ID da Despesa a ser deletada:");
            despesa2.IdDespesa = Convert.ToInt32(Console.ReadLine());

            DespesaDAO.Delete(despesa2);
            

            break;

        case 5:

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            List<Despesa> despesasList = new List<Despesa>();

            despesasList = DespesaDAO.List();

            foreach (var d in despesasList)
            {
                Console.WriteLine("Dados da despesa de ID " + d.IdDespesa + ".");
                Console.WriteLine("Valor: R$" + d.Valor);
                Console.WriteLine("Data Vencimento: " + d.DataVencimento);
                Console.WriteLine("Data Pagamento: " + d.DataPagamento);
                if (d.Situacao == true)
                {
                    Console.WriteLine("Situacão: Ativa");
                }
                else
                {
                    Console.WriteLine("Situacão: Inativa");
                }
                Console.WriteLine("ID do Caixa vinculado: " + d.Fk_Id_Caixa);
                Console.WriteLine("ID do Fornecedor vinculado: " + d.Fk_Id_Fornecedor);
                Console.WriteLine("");
            }

            break;
        default:
            break;
    }



} while (op != -0);