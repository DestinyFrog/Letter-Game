namespace letterGame {
//classes e estruturas instanciadas com informações do jogo
//classe que guarda variaveis e métodos sobre os niveis
public class Level {
    public int[] Map = new int[72];     //array de valores inteiros referente ao mapa
    public int win;                     //ponto do array onde esta a linha de chegada
    public int maxSteps;                //numero maximo de passos que podem ser dados
    public int start;                   //ponto de inicio do Player
    //método construtor que dá valor as variaveis acima
    public Level (int[] Map, int win, int maxSteps, int start){
        this.Map = Map;
        this.win = win;
        this.maxSteps = maxSteps;
        this.start = start;}}
//classe que guarda variaveis e métodos sobre o Player
public class Player{
    public string sprite = "A";         //sprite do Player
    public int updatePosition;          //posicao atual do Player
    public int actualSteps;             //numero de passos dado pelo Player

    //método construtor que da valor as variaveis acima
    public Player(int startPosition){
        this.updatePosition = startPosition;}
    public void changeSprite(string newSprite){
        this.sprite = newSprite;
    }
    //método que atualiza o movimento do player de acordo com a tecla pressionada
    public void updatePlayer(string key, Level lvl){
        if(this.actualSteps > lvl.maxSteps){
            Game.Lose();
        }else if(this.updatePosition == lvl.win){
            Game.Win();
        }else{
        switch (key){
            case "A":
                if(lvl.Map[this.updatePosition - 1] != 3){
                    this.updatePosition--;
                } actualSteps++;
                break;
            case "D":
                if(lvl.Map[this.updatePosition + 1] != 3){
                    this.updatePosition++;
                } actualSteps++;
                break;
            case "S":
                if(lvl.Map[this.updatePosition + 12] != 3){
                    this.updatePosition = this.updatePosition + 12;
                } actualSteps++;
                break;
            case "W":
                if(lvl.Map[this.updatePosition - 12] != 3){
                    this.updatePosition = this.updatePosition - 12;
                } actualSteps++;
                break;
            default:
                Game.Lose();
                break;
        }}
    }}
//
public class Enemie{
    //public int 
}
//      __________________________
//      classe que controla o jogo
public class Game{
    public static int index = 0;
    public static Level[] levels = new Level[3] {
        new Level(new int[72]{
        3,3,3,3,3,3,3,3,3,3,3,4,
        3,6,3,1,1,1,3,1,1,1,3,4,
        3,1,3,1,3,1,3,1,3,1,3,4,
        3,1,3,1,3,1,3,1,3,5,3,4,
        3,1,1,1,3,1,1,1,3,1,3,4,
        3,3,3,3,3,3,3,3,3,3,3,4}, 45, 23, 13)
        ,
        new Level(new int[72]{
        3,3,3,3,3,3,3,3,3,3,3,4,
        3,6,1,1,1,3,3,1,1,1,3,4,
        3,3,3,3,1,1,1,1,3,1,3,4,
        3,5,1,3,3,3,3,3,3,1,3,4,
        3,3,1,1,1,1,1,1,1,1,3,4,
        3,3,3,3,3,3,3,3,3,3,3,4}, 37, 23, 13)
        ,
        new Level(new int[72]{
        3,3,3,3,3,3,3,3,3,3,3,4,
        3,6,1,1,1,1,1,1,1,1,3,4,
        3,1,1,1,1,1,1,1,1,1,3,4,
        3,5,1,1,1,1,1,1,1,1,3,4,
        3,1,1,1,1,1,1,1,1,1,3,4,
        3,3,3,3,3,3,3,3,3,3,3,4}, 37, 23, 13)
    };

    //Variaveis de uso geral
    public static Level mainLevel = levels[index];
    public static Player pl = new Player(mainLevel.start); //instancia da variavel do Player

    //método principal de açao
    public static void Main(string[] args){
        top:
        BuildScreen(mainLevel.Map);
        pl.updatePlayer(Convert.ToString(Console.ReadKey().Key), mainLevel);
        goto top;
    }
    //método que limpa a tela, e pinta ela denovo 
    public static void BuildScreen(int[] lvl){
        Console.Clear();  //limpa a tela

        //estrutura de repetição de cada digito do mapa
        for(int i = 0; i < mainLevel.Map.Length; i += 1){ 
            if(i == pl.updatePosition){                             //se o digito, for igual a posiçao do player,
                Console.Write(Plot.NumberToLetter(2));              //o local se torna o Player,
            }else{                                                  //caso contrario,
                Console.Write(Plot.NumberToLetter(mainLevel.Map[i]));    //o local se tornara o digito padrao.
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        //escreve na tela o número de passos
        Console.WriteLine("numero de passos: " + pl.actualSteps + @"\" +  mainLevel.maxSteps);
    }

    //  Método de ação ao ganhar
    public static void Win(){
        Console.WriteLine("\n Voce venceu, Parabéns");
        Console.ReadKey();
        Console.Clear();
        if(index < levels.Length -1){
            NextLevel();
        }else{
            End();}}
    public static void Lose(){
        Console.WriteLine("\n Voce perdeu ???");
        Console.WriteLine(" Sério isso '-'");
        Console.ReadKey();
        Console.Clear();
        Environment.Exit(0);}

    public static void End(){
        Console.WriteLine("\n Fim do jogo");
        Console.ReadLine();
        Console.WriteLine(" A senha é C4L1GUL4.");
        Console.ReadKey();
        Console.Clear();
        Environment.Exit(0);}

    public static void NextLevel(){
        index++;
        mainLevel = levels[index];
        pl.actualSteps = 0;
        pl.updatePosition = mainLevel.start;
        Console.Clear();
        Console.WriteLine(" Level " + (index+1));
        Console.ReadKey();}
}

//classe com métodos e variaveis do sistema que opera o jogo
public class Plot{
    //método que converte 
    public static string NumberToLetter(int number){
        switch(number){
            case 1:
                return "   ";
            case 2:
                return " " + Game.pl.sprite + " ";
            case 3:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                return "=#=";
            case 4:
                return "\n";
            case 5:
                return " B ";
            case 6:
                return " A ";
            default:
                return "   ";
        }}
    }
}