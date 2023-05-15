using System;
using Sistema_UC12;
using Sistema_UC12.Classes;

class Program
{
    static void Main(string[] args)
    {
        void BarraCarregameno(string textoCarregamento){
            Console.WriteLine(textoCarregamento);
            Thread.Sleep(600);

            for (var contador = 0; contador <20; contador++){
            Console.Write("〉");
            Thread.Sleep(250);
        }
        }

         Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine(@$"
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦
♦  Seja Bem Vinda(o) ao Sistema de       ♦
♦  Cadastro de Pessoa Física e Jurídica! ♦
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");
        
        BarraCarregameno("INICIANDO..");

        List<PessoaFisica> listaPf = new List<PessoaFisica>();

        string? opcao;
        do {
        
            Console.Write(@$"
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦
♦  Escolha uma das Opções abaixo:        ♦");
            Console.WriteLine(@$"
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦
♦  1- Pessoa Física                      ♦
♦  2- Pessoa Jurídica                    ♦
♦                                        ♦
♦  0- Sair                               ♦
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");

        opcao = Console.ReadLine();

        switch (opcao) 
        {
        case "1":

        string? opcaoPF;
            do{
                Console.Clear();
                Console.Write(@$"
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦
♦  Escolha uma das Opções abaixo:        ♦");
                Console.WriteLine(@$"
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦
♦  1- Cadastrar Pessoa Física            ♦
♦  2- Mostrar Pessoas Físicas            ♦
♦                                        ♦
♦  0- Voltar ao menu anterior            ♦
♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦♦");

            opcaoPF = Console.ReadLine();
            switch (opcaoPF) 
            {
            case "1":
            PessoaFisica novapf = new PessoaFisica();
            Endereco endereco = new Endereco();

            Console.WriteLine("Digite o nome da Pessoa Fisica que deseja cadastrar");
            novapf.nome = Console.ReadLine();
                
            Console.WriteLine($"Digite o Logradouro de {novapf.nome} para cadastro:");
            endereco.logradouro = Console.ReadLine();

            Console.WriteLine($"Digite o número de {endereco.logradouro}:");
            endereco.numero = int.Parse(Console.ReadLine());
                
            Console.WriteLine("Digite o complemento do endereço:");
            endereco.complemento = Console.ReadLine();

            Console.WriteLine("Se trata de um local comercial? S/N");
            string endCom = Console.ReadLine().ToUpper();   
            if (endCom =="S") {
                endereco.enderecoComercial = true;
            } 
            else {
                endereco.enderecoComercial = false;
            }

            Console.WriteLine($"Digite o CPF de {novapf.nome}:");
            novapf.cpf = Console.ReadLine();

            Console.WriteLine("Digite a data de nascimento. Ex: DD/MM/AAAA");
            novapf.dataNascimento = DateTime.Parse(Console.ReadLine());
            bool idadevalidade = novapf.ValidarDataNascimento(novapf.dataNascimento);
                if(idadevalidade == true){
                    Console.WriteLine($"{novapf.nome} pode beber pinga!");
                } else {
                    Console.WriteLine($"Ih {novapf.nome}, vai ficar só no refri");
                }

            //listaPf.Add(novapf);

            using (StreamWriter sw = new StreamWriter($"{novapf.nome}.txt")) {
                sw.WriteLine(novapf.nome);
                sw.WriteLine(novapf.dataNascimento);
            }
            
            Console.WriteLine("Cadastro realizado com sucesso!!");
            Thread.Sleep(4000);
                break;
            case "2":

            Console.WriteLine("Digite Nome da Pessoa Fisica que deseja buscar informações:");
            string registro = Console.ReadLine();

            using (StreamReader sr = new StreamReader($"{registro}.txt")) {
                string linha;
                while ((linha = sr.ReadLine()) != null){
                    Console.WriteLine($"{linha}");
                }
            }
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadLine();

            //Console.Clear();
            //if (listaPf.Count > 0){
                //foreach(PessoaFisica cadaPessoa in listaPf){
                    //Console.Clear();
                    //Console.WriteLine(@$"
                    //Nome: {cadaPessoa.nome}
                    //Endereço: {cadaPessoa.endereco.logradouro}, {cadaPessoa.endereco.numero}, {cadaPessoa.endereco.complemento}
                    //Data de Nascimento: {cadaPessoa.dataNascimento}
                    //");
                //}
            //}else {
                //Console.WriteLine("Lista Vazia! Digite qualquer tecla para continuar");
                //Console.ReadLine();
            //}
                break;
            case "0":
                break;
            default:
            Console.Clear();
            Console.WriteLine("Opção inválida, por favor digite outra opção!");
            Thread.Sleep(2000);
                break;
            } 
        // Console.WriteLine($"O endereço do {novapf.nome} é {novapf.endereco.logradouro}, numero {novapf.endereco.numero}");
            } while (opcaoPF!= "0");
            break;
        case "2":             
        
                 // PessoaJuridica novapj = new PessoaJuridica();
                // novapj.nome = "Senai";
                // novapj.cnpj = "12345678910001";
                // novapj.razaoSocial = "Empresa Top1";

                // if (novapj.ValidarCNPJ(novapj.cnpj)){
                //     Console.WriteLine("CNPJ VÁLIDO");
                // } else {
                //     Console.WriteLine("CNPJ INVÁLIDO");
                // }
                // Console.WriteLine($"A razão social do {novapj.nome} é {novapj.razaoSocial}");
                // PessoaJuridica novapj = new PessoaJuridica();
                // novapj.nome = "Senai";
                // novapj.cnpj = "12345678910001";
                // novapj.razaoSocial = "Empresa Top1";

                // if (novapj.ValidarCNPJ(novapj.cnpj)){
                //     Console.WriteLine("CNPJ VÁLIDO");
                // } else {
                //     Console.WriteLine("CNPJ INVÁLIDO");
                // }
                // Console.WriteLine($"A razão social do {novapj.nome} é {novapj.razaoSocial}");
            break;
        case "0":
        Console.WriteLine("Obrigado por utilzar o nosso Sistema");
        BarraCarregameno("FINALIZANDO..");
        break;

        default:
        Console.Clear();
        Console.WriteLine("Opção inválida, por favor digite outra opção!");
        Thread.Sleep(800);
            break;
        }

    } while (opcao != "0");
    
}        
}


