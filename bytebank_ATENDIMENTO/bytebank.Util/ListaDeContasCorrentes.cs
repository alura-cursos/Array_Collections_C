using bytebank.Modelos.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao=0;
        public ListaDeContasCorrentes(int tamanhoInicial=5)
        {
            _itens = new ContaCorrente[tamanhoInicial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            _itens.SetValue(item, _proximaPosicao);
            VerificarCapacidade(_proximaPosicao + 1);
            _proximaPosicao++;
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (tamanhoNecessario <= _itens.Length) return;

            Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        }

        public void Remover(ContaCorrente conta)
        {
            var index = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (_itens[i] == conta)
                {
                    index = i;
                    break;
                }
            }

            for (int i = index; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ExibeLista()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                var conta = _itens[i];
                Console.WriteLine($"Indice[{i}] = " +
                    $"Conta:{conta.Conta} - " +
                    $"N° da Agência: {conta.Numero_agencia}");
            }
        }

        public ContaCorrente RecuperarContaNoIndice(int indice)
        {
            if (indice < 0 || indice >= _proximaPosicao)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }

            return _itens[indice];
        }

        public int Tamanho {
            get
            {
                return _proximaPosicao;
            }        
        }

        public ContaCorrente this[int indice]
        {
            get
            {
                return RecuperarContaNoIndice(indice);
            }
        }
     

    }
}
