//Console.WriteLine("Hello, world!");
namespace letterGame {

//classes e estruturas instanciadas com informações do jogo
//classe que guarda variaveis e métodos sobre os niveis
public class Level {
    public int[] Map = new int[72];     //array de valores inteiros referente ao mapa
    public int win;                     //ponto do array onde esta a linha de chegada
    public int maxSteps;                //numero maximo de passos que podem ser dados

    //método construtor que dá valor as variaveis acima
    public Level (int[] Map, int win, int maxSteps){
        this.Map = Map;
        this.win = win;
        this.maxSteps = maxSteps;}}

//classe que guarda variaveis e métodos sobre o Player
public class Player{
    private int startPosition;          //posiçao inicial do Player
    public int updatePosition;          //posicao atual do Player
    public int actualSteps;             //numero de passos dado pelo Player

    //método construtor que da valor as variaveis acima
    public Player(int startPosition){
        this.startPosition = startPosition;
        this.updatePosition = startPosition;}
    
    //método que atualiza o movimento do player de acordo com a tecla pressionada
    public void updatePlayer(string key, Level lvl){
        switch (key){
            case "A":
                if(lvl.Map[this.updatePosition - 1] != 3){
                    this.updatePosition--;
                    actualSteps++;
                }
                break;
            case "D":
                if(lvl.Map[this.updatePosition + 1] != 3){
                    this.updatePosition++;
                    actualSteps++;
                }
                break;
            case "S":
                if(lvl.Map[this.updatePosition + 12] != 3){
                    this.updatePosition = this.updatePosition + 12;
                    actualSteps++;
                }
                break;
            case "W":
                if(lvl.Map[this.updatePosition - 12] != 3){
                    this.updatePosition = this.updatePosition - 12;
                    actualSteps++;
                }
                break;
            default:
                Console.ReadLine();
                break;
        }
    }}

//      __________________________
//      classe que controla o jogo
public class Game{
    //instancia da variavel da fase
    public static Level lvl1 = new Level(new int[72]{
        3,3,3,3,3,3,3,3,3,3,3,4,
        3,1,3,1,1,1,3,1,1,1,3,4,
        3,1,3,1,3,1,3,1,3,1,3,4,
        3,1,3,1,3,1,3,1,3,5,3,4,
        3,1,1,1,3,1,1,1,3,1,3,4,
        3,3,3,3,3,3,3,3,3,3,3,4}, 45, 23);
    //instancia da variavel do Player
    public static Player pl = new Player(13);

    //método principal de açao
    public static void Main(string[] args){
        top:
        BuildScreen(lvl1.Map);
        pl.updatePlayer(Convert.ToString(Console.ReadKey().Key), lvl1);
        goto top;
    }
    //método que limpa a tela, e pinta ela denovo 
    public static void BuildScreen(int[] lvl){
        Console.Clear();  //limpa a tela

        //estrutura de repetição de cada digito do mapa
        for(int i = 0; i < lvl1.Map.Length; i += 1){ 
            if(i == pl.updatePosition){                             //se o digito, for igual a posiçao do player,
                Console.Write(Plot.NumberToLetter(2));              //o local se torna o Player,
            }else{                                                  //caso contrario,
                Console.Write(Plot.NumberToLetter(lvl1.Map[i]));    //o local se tornara o digito padrao.
            }
        }

        //escreve na tela o número de passos
        Console.WriteLine("numero de passos: " + pl.actualSteps + @"\" + lvl1.maxSteps);
    }
}

//classe com métodos e variaveis do sistema que opera o jogo
public class Plot{
    public static string NumberToLetter(int number){
        switch(number){
            case 1:
                return " . ";
                break;
            case 2:
                return " A ";
                break;
            case 3:
                return " # ";
                break;
            case 4:
                return "\n";
                break;
            case 5:
                return " ^ ";
                break;
            case 6:
                return " V ";
                break;
            default:
                return "   ";
                break;
            }
        }
    }
}