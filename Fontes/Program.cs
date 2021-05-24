using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "4")
            {

                switch (opcaoUsuario)
                {

                    case "1":
                        //Inserir novo aluno
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)) {
                            aluno.Nota = nota;
                        } else{
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }
                        
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        //Listar alunos
                        Console.WriteLine("***************ALUNOS***************");
                        foreach(var a in alunos){
                            if(!string.IsNullOrEmpty(a.Nome)){
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        Console.WriteLine("************************************");

                        break;

                    case "3":
                        //Calcular a média geral
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        decimal media = 0;

                        for (int i=0; i < alunos.Length; i++){

                            if(!string.IsNullOrEmpty(alunos[i].Nome)){
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }                            
                        }

                        Conceito conceitoGeral;

                        if (nrAlunos > 0){
                            media = notaTotal / nrAlunos;
                        }

                        if (media < 3) {
                            conceitoGeral = Conceito.E;
                        } else if (media < 5) {
                            conceitoGeral = Conceito.D;
                        } else if (media < 7) {
                            conceitoGeral = Conceito.C;
                        } else if (media < 8) {
                            conceitoGeral = Conceito.B;
                        } else {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine("***************MEDIA GERAL***************");
                        Console.WriteLine($"A média geral é: {media} - Conceito: {conceitoGeral}");
                        Console.WriteLine("*****************************************");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular a média geral");
            Console.WriteLine("4- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
