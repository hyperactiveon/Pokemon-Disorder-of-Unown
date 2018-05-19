## Pokemon: Disorder of Unown
![logo](https://i.imgur.com/4W9cPzE.png)

Um jogo, baseado em Pokemon, porém utilizando da mecânica de sorts!

### História:
![Ashley](https://i.imgur.com/DUyTHVb.png)

A pequena Ashley era uma garota muito alegre e feliz de 9 anos, até certo dia em que, em um terrível acidente em uma caverna, acabou perdendo seus pais, que eram arqueólogos. Desde este dia, a pequena Ashley, vivia triste e cabisbaixa por todos os lugares que passava. Até que um dia, tentando entender como tal tragédia teria acontecido, ela resolveu explorar a caverna. Para sua surpresa, acabou indo de encontro a uma antiga tumba de Unowns e acabou os libertando sem perceber. Os pequenos Unowns, seres muito sensíveis a emoções humanas e muito poderosos, acabaram por entrar na cabeça de Ashley e enlouqueceram em meio a sua tristeza. Eis que voce surge no horizonte, e decide ajudá-la, pois o chaos que os Unowns estão causando, esta afetando a região fazendo com que coisas fiquem fora do lugar. Cabe a você, acabar com a desordem dos Unown!


### Instruções:

![Unown](https://i.imgur.com/4y7PQxo.png)

Ao iniciar, o jogador deve escolher um Pokémon a sua escolha para realizar as batalhas contra enxames de Unowns para salvar a pequena Ashley.
O jogo é composto por batalhas sucessivas, onde você apenas contará com o Pokémon escolhido logo no início. Ele pode realizar 5 tipos de ataque, que representam os 5 tipos de método de ordenação. Cada enxame de Unowns, representa um vetor de números. Tanto os valores do vetor, quanto o tamanho do mesmo, são gerados aleatóriamente. O tamanho do vetor sempre será múltiplo de 5 e terá tamanho máximo de 50. Os valores do vetor poderão ser de 0 a 99, podendo ser repetidos. O vetor tem uma pequena possibilidade de vir ordenado crescentemente ou decrescentemente. Caso o vetor chegue ao tamanho de 0 ou menor, o inimigo será derrotado e um novo aparecerá até um limite de 10. 
Ao realizar um ataque, temos 3 possibilidades:
Caso realize um ataque que representa o melhor método de ordenação para aquele vetor, o mesmo, terá seu tamanho diminuído em 10 e será randomizado novamente, nenhum dano será dado ao Pokémon.
Caso realize um ataque que seja representa qualquer método diferente do melhor ou do pior método de ordenação, o vetor terá seu tamanho diminuído em 5, o Pokémon receberá 5 de dano e o vetor será randomizado novamente.
Caso realize um ataque que representa o pior método de ordenação para aquele vetor, o mesmo não terá seu tamanho reduzido, o Pokémon recebe 10 de dano e o vetor será novamente randomizado.

O jogador possui 2 recursos que deverão ser levados em conta:

**HP** = Pontos de vida do Pokémon. Representa quanto de vida o Pokémon ainda possui. Inicia-se em 100. Caso faça uma escolha de método de ordenação não tão eficiente, ele poderá receber 0, 5 ou 10 de dano a cada ataque. Caso ela chegue a zero, você perde.
**PP** = Pontos de Poder do Pokémon. Cada ataque tem um custo próprio e deverá ser gasto para realizar o ataque (método de ordenação. A cada rodada, você ganha 2 de PP. Caso você chegue a 0 ou seus pontos de PP sejam menores que o ataque que desejar utilizar, o mesmo, não poderá ser usado e caso, o PP seja menor que o menor dos custos de ataque, você passará a rodada automaticamente.

Caso o jogador chegue a vencer 10 enxames de Unowns, ele vence o jogo. Caso perca antes, o jogo pode ser iniciado novamente desde o inicio.

### Ataques (métodos de ordenação) disponíveis:

1. Bubble Sort
2. Selection Sort
3. Insertion Sort
4. Merge Sort
5. Quick Sort

### Download

[Download](https://mega.nz/#!PccESJpa!c4NJH1zbrbNwLLIwaS78rfEuv__fSZ8ft9uM81c7qiE)
