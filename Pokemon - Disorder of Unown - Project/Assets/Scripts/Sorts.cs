using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorts : MonoBehaviour {

	//Bubble Sort Method
	public void bubbleSort(Game controller){
		int i, aux, j;
		int have_change = 1;
		i = 0;

		while(i <= controller.bubbleRelatorio.n_e_o && have_change == 1){ // la�o com a quantidade de elementos do vetor e enquanto houver troca
			have_change = 0; // la�o que percorre da primeira � pen�ltima posi��o do vetor
			for(j=0;j<((controller.bubbleRelatorio.n_e_o)-1);j++){
				(controller.bubbleRelatorio.n_comp)++; // acrescenta 1 compara��o
				if(controller.bubbleRelatorio.vet[j] > controller.bubbleRelatorio.vet[j+1]){
					controller.bubbleRelatorio.n_comp++;
					have_change = 1;// sinaliza que houve troca nesta itera��o
					(controller.bubbleRelatorio.n_mov)++;// acrescenta 1 movimenta��o
					aux = controller.bubbleRelatorio.vet[j];
					controller.bubbleRelatorio.vet[j] = controller.bubbleRelatorio.vet[j+1];
					controller.bubbleRelatorio.vet[j+1] = aux;
				}
			}
			i++;
		}
	}


	//Selection Sort Method
	public void selectionSort(Game controller){
		int choosen, smaller, pos, j, i;
		for( i=0;i<controller.selectionRelatorio.n_e_o-1;i++){  // laço com a quantidade de elementos do vetor - 1
			(controller.selectionRelatorio.n_mov)++; // acrescenta 1 movimentação
			choosen = controller.selectionRelatorio.vet[i];
			smaller = controller.selectionRelatorio.vet[i+1];
			pos = i + 1;
			for(j=i+1; j<controller.selectionRelatorio.n_e_o; j++){  // laço que percorre os elementos à esquerda do número eleito ou até encontrar a posição para recolocação do eleito em ordem crescente
				(controller.selectionRelatorio.n_comp)++; // acrescenta 1 comparação
				if(controller.selectionRelatorio.vet[j] < smaller){
					smaller = controller.selectionRelatorio.vet[j];
					pos = j;
				}
			}
			if(smaller < choosen){
				(controller.selectionRelatorio.n_mov)++; // acrescenta 1 movimentação
				controller.selectionRelatorio.vet[i] = controller.selectionRelatorio.vet[pos];
				controller.selectionRelatorio.vet[pos] = choosen;
			}
		}
	}


	//Insertion Sort Method
	public void insertionSort(Game controller){
		int choosen, j,i;
		// la�o com a quantidade de elementos do vetor - 1
		for( i=1;i<=((controller.insertionRelatorio.n_e_o)-1);i++){
			choosen = controller.insertionRelatorio.vet[i];
			j = i - 1;
			(controller.insertionRelatorio.n_comp)++; // acrescenta 1 compara��o
			// la�o que percorre os elementos � esquerda do n�mero choosen ou at� encontrar a posi��o para recoloca��o do choosen em ordem crescente
			while(j >= 0 && controller.insertionRelatorio.vet[j] > choosen){
				(controller.insertionRelatorio.n_comp)++; // acrescenta 1 compara��o
				(controller.insertionRelatorio.n_mov)++; // acrescenta 1 compara��o
				controller.insertionRelatorio.vet[j+1] = controller.insertionRelatorio.vet[j];
				j--;
			}
			controller.insertionRelatorio.vet[j+1] = choosen;
		}
	}


	//Merge Sort Method
	public void merge(Game controller, int ini, int end, int mid){ //Merge Aux Function
		int posFree, ini1, ini2, i;
		int[] aux = new int[end + 1];
		ini1 = ini;
		ini2 = mid + 1;
		posFree = ini;
		// laço repete enquanto houver elementos nos dois subvetores
		while(ini1 <= mid && ini2 <= end){
			(controller.mergeRelatorio.n_comp)++; // acrescenta 1 comparação
			if(controller.mergeRelatorio.vet[ini1] <= controller.mergeRelatorio.vet[ini2]){
				aux[posFree]=controller.mergeRelatorio.vet[ini1];
				ini1++;
			}else{
				aux[posFree]=controller.mergeRelatorio.vet[ini2];
				ini2++;
			}
			posFree++;
		}
		// se ainda existem números no primeiro vetor que não foram intercalados, copia para aux[]
		for(i=ini1; i<=mid; i++){
			aux[posFree]=controller.mergeRelatorio.vet[i];
			posFree++;
		}
		// se ainda existem números no segundo vetor que não foram intercalados, copia para aux[]
		for(i=ini2; i<=end; i++){
			aux[posFree]=controller.mergeRelatorio.vet[i];
			posFree++;
		}
		// retorna os valores do vetor aux para o vetor V
		for(i=ini; i<=end; i++)  {
			(controller.mergeRelatorio.n_mov)++; // acrescenta 1 movimentação
			controller.mergeRelatorio.vet[i] = aux[i];
		}
	}

	public void mergeSort(Game controller, int ini, int end){ //Merge Sort Recursive Function
		int mid;
		if(ini < end){
			mid = Mathf.RoundToInt((ini + end) / 2);
			mergeSort(controller, ini, mid);
			mergeSort(controller, mid+1, end);
			merge(controller, ini, end, mid);
		}
	}

	//Quick Sort Method
	public void quickSort(Game controller, int low, int high){ //Quick Sort Recursive Function
		int q;
		if(low < high){
			q = partition(controller, low,high);
			quickSort(controller, low, q);
			quickSort(controller, q+1, high);
		}
	}

	public int partition(Game controller, int low, int high){ //Quick Aux Function
		int pivot, i, j,aux;
		pivot = controller.quickRelatorio.vet[(low+high)/2];
		i = low - 1;
		j = high + 1;
		while(i < j){
			do{// encontra o primeiro elemento menor que o pivo, a partir do fim, para trocar de lado
				j--;
				(controller.quickRelatorio.n_comp)++;// acrescenta 1 comparação
			}while (controller.quickRelatorio.vet[j] > pivot);
			do{// encontra o primeiro elemento maior que o pivo, a partir do inicio, para trocar de lado
				i++;
				(controller.quickRelatorio.n_comp)++; // acrescenta 1 comparação
			}while(controller.quickRelatorio.vet[i] < pivot);
			if(i < j){ // realiza troca de elementos do vetor
				aux = controller.quickRelatorio.vet[i];
				controller.quickRelatorio.vet[i] = controller.quickRelatorio.vet[j];
				controller.quickRelatorio.vet[j] = aux;
				(controller.quickRelatorio.n_mov)++;   // acrescenta 1 movimentação
			}
		}
		return j;
	}

}
