using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controler : MonoBehaviour {

	[Header("Scene de Selecao de pokemon")]
	public Text txtdesc;
	public Text txtCreditos;
	public static string pokemon = "";
	public string[] desc = new string[6];

	public GameObject pokemonHolder = null;
	public GameObject badEnd;
	public GameObject goodEnd;

	public AudioClip badEndSound;
	public AudioClip goodEndSound;

	public Sprite[] pokemonSprites;

	Game game;

	// Use this for initialization
	void Start () {
		desc[0] = "Absol, o Pokémon de Desastre. Quando desastres são detectados com seu chifre, Absol desce das montanhas para avisar as pessoas.";
		desc[1] = "Eles não podem ver, então eles atacam e mordem para aprender sobre seus arredores. Seus corpos estão cobertos de feridas.";
		desc[2] = "Ditto, Pokémon Transformador. Um tipo normal. Ditto pode reorganizar as células de seu corpo para mudar para outras formas de vida.";
		desc[3] = "Growlithe, o Pokémon filhote de cachorro. Growlithe é muito leal e não se move a menos que seu treinador o comande.";
		desc[4] = "Mimikyu, o Pokemon Disfarce. Um tipo fantasma e fada. Ele usa uma capa de cabeça esfarrapada para parecer um Pikachu, mas pouco se sabe sobre esse Pokémon. Dizem que um estudioso que uma vez tentou olhar para dentro da cabeça esfarrapada, encontrou seu fim.";
		desc[5] = "Vulpix, o Pokémon Raposa. Antes de evoluir, a cauda de seis partes da Vulpix pode se se tornar tão quente quanto uma labareda de fogo.";

		if (pokemonHolder != null) {
			if (pokemon == "absol")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [0];
			if (pokemon == "deino")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [1];
			if (pokemon == "ditto")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [2];
			if (pokemon == "growlithe")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [3];
			if (pokemon == "mimikyu")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [4];
			if (pokemon == "vulpix")
				pokemonHolder.GetComponent<Image> ().sprite = pokemonSprites [5];
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void OpenGit(){
		Application.OpenURL ("https://github.com/welintonfm/pokemon-disorder-of-unown");
		//Application.OpenURL ("https://docs.google.com/document/d/1u8kqIU3Jp55pNmnwlfIFbxKTm8gRZFT078hLFaZBnB4/edit?usp=sharing");
	}

	public void atualizaDesc(string pok){
		pokemon = pok;

		switch (pokemon) {
		case "absol":
			txtdesc.text = desc [0];
			break;
		case "deino":
			txtdesc.text = desc [1];
			break;
		case "ditto":
			txtdesc.text = desc [2];
			break;
		case "growlithe":
			txtdesc.text = desc [3];
			break;
		case "mimikyu":
			txtdesc.text = desc [4];
			break;
		case "vulpix":
			txtdesc.text = desc [5];
			break;
		}
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void ChangeScene(string SceneName)
	{
		if(pokemon != "" || SceneManager.GetActiveScene().name == "MainMenu")
			Application.LoadLevel (SceneName);
	}

	public void endGame(bool final){
		if (final) {
			txtCreditos.text = "Você derrotou Unowns e salvou Ashley...\n\n\n\n\n\n\n\n\n\n\nCreditos:\n\nCaroline Lopes Resek  - Logistica\nHenrique R. Cipriano - Game Designer e Programador\nJosé Francisco - Audio/Visual\nMatheus Silva Souza - Designer Gráfico\nWelinton Faria Máximo - Logistica e Programador\n\n\nColaboradores:\n\nRuan Michel Adabo - Game Designer e Programador\nÁdrian Castello - Designer Gráfico\n\n\n\n\n\n\n\n\nFIM\n\n\n\n\n\n\n[Aperte ESPACO para voltar para o Menu]";
			goodEnd.SetActive (true);
			goodEnd.transform.parent.GetComponent<Animator> ().SetTrigger ("EndGame");
			this.gameObject.GetComponent<AudioSource> ().Stop ();
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot(goodEndSound);
		} else {
			txtCreditos.text = "Você foi derrotado pelos Unowns...\n\n\n\n\n\n\n\n\n\n\nCreditos:\n\nCaroline Lopes Resek  - Logistica\nHenrique R. Cipriano - Game Designer e Programador\nJosé Francisco - Audio/Visual\nMatheus Silva Souza - Designer Gráfico\nWelinton Faria Máximo - Logistica e Programador\n\n\nColaboradores:\n\nRuan Michel Adabo - Game Designer e Programador\nÁdrian Castello - Designer Gráfico\n\n\n\n\n\n\n\n\nFIM\n\n\n\n\n\n\n[Aperte ESPACO para voltar para o Menu]";
			badEnd.SetActive (true);
			badEnd.transform.parent.GetComponent<Animator> ().SetTrigger ("EndGame");
			this.gameObject.GetComponent<AudioSource> ().Stop ();
			this.gameObject.GetComponent<AudioSource> ().PlayOneShot(badEndSound);
		}
	}
}
