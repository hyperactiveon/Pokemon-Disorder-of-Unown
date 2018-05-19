using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public static string type;
	public static string pokemon;
	public static int hpPlayer;
	public static int pp;
	public int round;
	public static bool resultado;

	public int bubble_pp = 2;
	public int insertion_pp = 2;
	public int selection_pp = 2;
	public int merge_pp = 4;
	public int quick_pp = 5;

	public GameObject roundImage;
	public GameObject buttons;

	public Text txthp;
	public Text txtpp;
	public Text txtvetor;
	public Text txtround;

	public VetOrd bubbleRelatorio;
	public VetOrd selectionRelatorio;
	public VetOrd insertionRelatorio;
	public VetOrd mergeRelatorio;
	public VetOrd quickRelatorio;

	public Sprite[] spritesUn;
	public GameObject[] unowns;
	public int[] unonwsNum;

	public AudioClip[] battleClips;

	int melhorChoice;
	int piorChoice;

	Sorts sortObj;

	public int tamanhoVetor;
	bool ending = false;
	bool stoping = false;
	// Use this for initialization
	void Start () {
		round = 1;
		tamanhoVetor = 30;
		txtround.text = round.ToString();
		hpPlayer = 100;
		pp = 100;
		roundImage.SetActive (true);

		sortObj = new Sorts ();

		bubbleRelatorio = new VetOrd();
		selectionRelatorio = new VetOrd();
		insertionRelatorio = new VetOrd();
		mergeRelatorio = new VetOrd();
		quickRelatorio = new VetOrd();

		inicializaGame(true);	
		realizaSorts ();
	}

	// Update is called once per frame
	void Update () {	
		if (!this.gameObject.GetComponent<AudioSource> ().isPlaying && !ending) {
			this.gameObject.GetComponent<AudioSource> ().clip = battleClips [Random.Range (0, 6)];
			this.gameObject.GetComponent<AudioSource> ().Play ();
		}

		if (hpPlayer <= 0) {
			hpPlayer = 0;
			Fim (false);
		}

		if (tamanhoVetor <= 0)
			Fim (true);
	
	//Hack Session
	//	if (Input.GetKeyDown (KeyCode.L))
	//		hpPlayer = 0; 
	//	if (Input.GetKeyDown (KeyCode.K))
	//		round = 11;

		if (ending && Input.GetKeyDown(KeyCode.Space)) 
			Application.LoadLevel ("MainMenu");

		if (round == 11 && !stoping) {
			ending = true;
			stoping = true;
			this.gameObject.GetComponent<Controler> ().endGame (true);
		}
	}

	void geraVetorAleatorio(){
		for(int i = 0; i < tamanhoVetor;i++)
			bubbleRelatorio.vet[i] = Random.Range(0,tamanhoVetor);
	}

	void geraVetorCrescente(){
		for(int i = 0; i < tamanhoVetor;i++)
			bubbleRelatorio.vet[i] = i;
	}

	void geraVetorDescente(){
		for(int i = tamanhoVetor-1; i >= 0;i--)
			bubbleRelatorio.vet[i] = i;
	}

	void realizaSorts(){
		List<int> numeros = new List<int> ();

		melhorChoice = 99999999;
		piorChoice = 0;

		sortObj.bubbleSort (this);
		sortObj.insertionSort (this);
		sortObj.selectionSort (this);
		sortObj.mergeSort (this, 0, tamanhoVetor-1);
		sortObj.quickSort (this, 0, tamanhoVetor-1);

		bubbleRelatorio.soma = bubbleRelatorio.n_comp + bubbleRelatorio.n_mov;
		selectionRelatorio.soma = selectionRelatorio.n_comp + selectionRelatorio.n_mov;
		insertionRelatorio.soma = insertionRelatorio.n_comp + insertionRelatorio.n_mov;
		mergeRelatorio.soma = mergeRelatorio.n_comp + mergeRelatorio.n_mov;
		quickRelatorio.soma = quickRelatorio.n_comp + quickRelatorio.n_mov;

		numeros.Add (bubbleRelatorio.soma);
		numeros.Add (selectionRelatorio.soma);
		numeros.Add (insertionRelatorio.soma);
		numeros.Add (mergeRelatorio.soma);
		numeros.Add (quickRelatorio.soma);

		foreach (int aux in numeros) {
			if (aux < melhorChoice)
				melhorChoice = aux;
			if (aux > piorChoice)
				piorChoice = aux;
		}
	}

	void inicializaVetOrd(){
		if (tamanhoVetor <= 0)
			return;
		
		int randomChance = Random.Range (0, 101);

		bubbleRelatorio.n_e_o = tamanhoVetor;
		bubbleRelatorio.n_comp = 0;
		bubbleRelatorio.n_mov = 0;
		bubbleRelatorio.vet = new int[tamanhoVetor];

		if (randomChance <= 20)
			geraVetorCrescente ();
		if (randomChance > 20 && randomChance < 80)
			geraVetorAleatorio ();
		if (randomChance >= 80)
			geraVetorDescente ();

		selectionRelatorio.n_e_o = tamanhoVetor;
		selectionRelatorio.n_comp = 0;
		selectionRelatorio.n_mov = 0;
		selectionRelatorio.vet = new int[tamanhoVetor];
		for(int i = 0; i < tamanhoVetor;i++){
			selectionRelatorio.vet[i] = bubbleRelatorio.vet[i];
		}

		insertionRelatorio.n_e_o = tamanhoVetor;
		insertionRelatorio.n_comp = 0;
		insertionRelatorio.n_mov = 0;
		insertionRelatorio.vet = new int[tamanhoVetor];
		for(int i = 0; i < tamanhoVetor;i++){
			insertionRelatorio.vet[i] = bubbleRelatorio.vet[i];
		}

		mergeRelatorio.n_e_o = tamanhoVetor;
		mergeRelatorio.n_comp = 0;
		mergeRelatorio.n_mov = 0;
		mergeRelatorio.vet = new int[tamanhoVetor];
		for(int i = 0; i < tamanhoVetor;i++){
			mergeRelatorio.vet[i] = bubbleRelatorio.vet[i];
		}

		quickRelatorio.n_e_o = tamanhoVetor;
		quickRelatorio.n_comp = 0;
		quickRelatorio.n_mov = 0;
		quickRelatorio.vet = new int[tamanhoVetor];
		for(int i = 0; i < tamanhoVetor;i++){
			quickRelatorio.vet[i] = bubbleRelatorio.vet[i];
		}

		AtualizaVetorPanel ();
		realizaSorts ();
	}

	void inicializaGame(bool reiniciar){
		inicializaVetOrd();
		for (int i = 0; i < 10; i++) {
			unowns [i].GetComponent<Image> ().sprite = spritesUn [i];
		}

		if (reiniciar)
			hpPlayer = 100;
	}

	public void AtualizaVetorPanel(){
		string output = "";

		for (int i = 0; i < tamanhoVetor; i++) {
			output += bubbleRelatorio.vet [i].ToString ()+" ";	
		}
		txtvetor.text = output;
	}

	public void AtualizaHP()
	{
		txthp.text = hpPlayer.ToString();
	}

	public void AtualizaPP()
	{
		txtpp.text = pp.ToString();
		txtpp.color = new Color (0, 0, 0, 1);
	}

	public void MostraPPGasto(string metodo){
		string ppAux = pp.ToString ();
		txtpp.color = new Color (1, 0, 0, 1);
		switch (metodo) {
			case "quick":
				ppAux = checaNegativo (int.Parse(ppAux) - quick_pp);
				txtpp.text = ppAux;
				break;
			case "merge":
				ppAux = checaNegativo (int.Parse(ppAux) - merge_pp);
				txtpp.text = ppAux;
				break;
			case "selection":
				ppAux = checaNegativo (int.Parse(ppAux) - selection_pp);
				txtpp.text = ppAux;
				break;
			case "bubble":
				ppAux = checaNegativo (int.Parse(ppAux) - bubble_pp);
				txtpp.text = ppAux;
				break;
			case "insertion":
				ppAux = checaNegativo (int.Parse(ppAux)- insertion_pp);
				txtpp.text = ppAux;
				break;
		}
	}

	string checaNegativo(int ppAux){
		if (ppAux > 0)
			return ppAux.ToString(); 
		
		return 0.ToString();
	}

	public void AtaqueBubble()
	{
		if (pp < bubble_pp)
			return;

		//Medio caso
		if (bubbleRelatorio.soma < piorChoice && bubbleRelatorio.soma > melhorChoice){
			tamanhoVetor -= 5;
			destroyUnowns (5);
			Disorder (5);
			pp -= bubble_pp;
			return;
		}
		//Melhor caso
		if (bubbleRelatorio.soma <= melhorChoice){
			tamanhoVetor -= 10;
			destroyUnowns (10);
			Disorder (0);
			pp -= bubble_pp-1;
			return;
		}
		//Pior caso
		if(bubbleRelatorio.soma >= piorChoice){
			tamanhoVetor -= 0;
			Disorder (10);
			pp -= bubble_pp;
			return;
		}
	}
	public void AtaqueQuick()
	{
		if (pp < quick_pp)
			return;

		//Medio caso
		if (quickRelatorio.soma < piorChoice && quickRelatorio.soma > melhorChoice){
			tamanhoVetor -= 5;
			destroyUnowns (5);
			Disorder (5);
			pp -= quick_pp;
			return;
		}
		//Melhor caso
		if (quickRelatorio.soma <= melhorChoice){
			tamanhoVetor -= 10;
			destroyUnowns (10);
			Disorder (0);
			pp -= quick_pp-1;
			return;
		}
		//Pior caso
		if(quickRelatorio.soma >= piorChoice){
			tamanhoVetor -= 0;
			Disorder (10);
			pp -= quick_pp;
			return;
		}
	}
	public void AtaqueMerge()
	{
		if (pp < merge_pp)
			return;

		//Medio caso
		if (mergeRelatorio.soma < piorChoice && mergeRelatorio.soma > melhorChoice){
			tamanhoVetor -= 5;
			destroyUnowns (5);
			Disorder (5);
			pp -= merge_pp;
			return;
		}
		//Melhor caso
		if (mergeRelatorio.soma <= melhorChoice){
			tamanhoVetor -= 10;
			destroyUnowns (10);
			Disorder (0);
			pp -= merge_pp-1;
			return;
		}
		//Pior caso
		if(mergeRelatorio.soma >= piorChoice){
			tamanhoVetor -= 0;
			Disorder (10);
			pp -= merge_pp;
			return;
		}
	}
	public void AtaqueSelection()
	{
		if (pp < selection_pp)
			return;

		//Medio caso
		if (selectionRelatorio.soma < piorChoice && selectionRelatorio.soma > melhorChoice){
			tamanhoVetor -= 5;
			destroyUnowns (5);
			Disorder (5);
			pp -= selection_pp;
			return;
		}
		//Melhor caso
		if (selectionRelatorio.soma <= melhorChoice){
			tamanhoVetor -= 10;
			destroyUnowns (10);
			Disorder (0);
			pp -= selection_pp-1;
			return;
		}
		//Pior caso
		if(selectionRelatorio.soma >= piorChoice){
			tamanhoVetor -= 0;
			Disorder (10);
			pp -= selection_pp;
			return;
		}
	}

	public void AtaqueInsertion()
	{
		if (pp < insertion_pp)
			return;
		
		//Medio caso
		if (insertionRelatorio.soma < piorChoice && insertionRelatorio.soma > melhorChoice){
			tamanhoVetor -= 5;
			destroyUnowns (5);
			Disorder (5);
			pp -= insertion_pp;
			return;	
		}
		//Melhor caso
		if (insertionRelatorio.soma <= melhorChoice){
			tamanhoVetor -= 10;
			destroyUnowns (10);
			Disorder (0);
			pp -= insertion_pp-1;
			return;
		}
		//Pior caso
		if(insertionRelatorio.soma >= piorChoice){
			tamanhoVetor -= 0;
			Disorder (10);
			pp -= insertion_pp;
			return;
		}
	}

	void Disorder(int ataque){
		inicializaVetOrd ();
		hpPlayer -= ataque;
		AtualizaHP ();
	}

	void transitionIn(){
		SetarBotoes (false);
		Animator anim = roundImage.GetComponent<Animator> ();
		anim.SetTrigger ("Transition");
		Invoke ("transitionOut", 2);
	}

	void transitionOut(){
		SetarBotoes (true);
	}

	void SetarBotoes(bool comando){
		for (int i = 0; i < buttons.transform.childCount; i++) {
			buttons.transform.GetChild (i).GetComponent<Button> ().interactable = comando;
		}
	}

	void reiniciarInimigo(){
		round++;
		txtround.text = round.ToString();
		pp += 5;
		tamanhoVetor = Random.Range (1, 11) * 5;
		inicializaGame (false);
	}

	 public void Fim(bool resultado)
	{
		if (resultado) {
			if(round < 11){
				transitionIn ();
				reiniciarInimigo ();
			}
		}
		else
		{
			ending = true;
			this.gameObject.GetComponent<Controler> ().endGame (false);
		}
	}

	bool checaVetor(int elemento, List<int> lista){
		foreach (int aux in lista)
			if (elemento == aux)
				return true;

		return false;
	}

	void destroyUnowns(int quantidade){
		for(int i = 0; i < quantidade; i++) {
			Animator anim = unowns [i].GetComponent<Animator> ();
			anim.SetTrigger ("Fade");
			Invoke ("getUnownBack", 1);
		}	
	}

	void getUnownBack(){
		foreach (GameObject aux in unowns) {
			Animator anim = aux.GetComponent<Animator> ();
			anim.SetTrigger ("FadeIn");
		}
	}
}