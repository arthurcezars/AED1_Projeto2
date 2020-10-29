using System;
using System.Collections.Generic;

class MainClass {
  public static void Main (string[] args) {
    string nome, rua, pagar, continuar = "s";
    int numeroRua, cp, quni, quniOrigin;
    double vtotal = 0; 
    Carrinho car = new Carrinho("NomeCliente", "NomeProduto", 1, 10);
    Cliente cli = new Cliente("Nome", "Rua", 0);
    Loja lo = new Loja();

    Console.Write("Informe o seu nome: ");
    nome = Console.ReadLine();
    Console.Write("Informe o nome da rua: ");
    rua = Console.ReadLine();
    Console.Write("Informe o numero da casa: ");
    numeroRua = int.Parse(Console.ReadLine());

    cli = new Cliente(nome, rua, numeroRua);
    cli.listaCliente.Add(cli);

    Console.WriteLine();
    for(int i = 0; i < lo.descricao.Count; i++){
      Console.WriteLine("Codigo produto: "+ i +" - Nome produto: "+ lo.descricao[i] +" / Preço : R$"+ lo.preco[i] +" / Unidade disponível: "+ lo.quanti[i]);
    }

    while(continuar == "s"){
      Console.Write("Insira o codigo do produto que deseja comprar: ");
      cp = int.Parse(Console.ReadLine());
      Console.Write("Insira quantas unidades deseja comprar: ");
      quni = int.Parse(Console.ReadLine());

      if(quni <= lo.quanti[cp]){
        quniOrigin = lo.quanti[cp];
        lo.quanti[cp] = lo.quanti[cp] - quni;
        vtotal = vtotal + (quni*lo.preco[cp]);

        car = new Carrinho(cli.getNome(), lo.descricao[cp], quni, quni*lo.preco[cp]);
        car.listaCar.Add(car);
      } else{
        Console.WriteLine("A quantidade que tentou inserir é maior que a presente em estoque!");
      }

      Console.WriteLine("Continuar comprando S/N?");
      continuar = Console.ReadLine();

      if(continuar == "n"){
        Console.WriteLine("Deseja gerar um boleto para efetuar o pagamento S/N?");
        Console.WriteLine("Valor total: R$"+ vtotal);
        pagar = Console.ReadLine();

        if(pagar == "s"){
          Random rnd = new Random();
          //Simula gerar um numero de boleto
          Console.WriteLine("Numero boleto"+$"{rnd.Next(),15:N0}");

          Console.WriteLine("Pressione qualquer tecla para ver a lista de produtos adquiridos");
          Console.ReadKey();

          for(int i = 0; i < car.listaCar.Count; i++){
            Console.WriteLine("Cliente: "+ car.listaCar[i].getCliente() +" / Produto: "+ car.listaCar[i].getProduto() +" / Quantidade: "+ car.listaCar[i].getQuantidade() +" / Total: "+ car.listaCar[i].getValor());
          }
        }
      }

    }

  }
}