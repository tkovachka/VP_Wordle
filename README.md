# Проектна задача по Визуелно Програмирање 

## Wordle 
##### Теодора Ковачка, Ива Георгиева, Ана Ѓоргон

## 1. Опис на проектната 

Играта што ја имплементираме е со истата идеја како постоечката Wordle (Линк: https://www.nytimes.com/games/wordle/index.html). Целта е во 5 обиди и за најмногу 5 минути, корисникот да погоди збор избран по случаен избор. 
Во нашата имплементација, разликата е тоа што корисникот има можност да избере дали ќе погодува збор од 5,6 или 7 букви. 

## 2. Упатство за користење 

### 2.1 Почеток на нова игра 

При отворање на апликацијата, се појавува форма Intro, односно вовед во играта, каде што има упатство за како се игра играта (се бира број за од колку букви ќе се состои зборот преку Numeric Up And Down, на десната страна има слика со објаснување за боите во кои се означени буквите при погодување, при клик на копчето "Start" играта почнува и тајмерот почнува да се намалува од 05:00. Во еден ред се испишуваат буквите и се клика "Enter" за да се погоди зборот.)

Изглед на воведот:


![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/bcaea90a-b0ac-401d-827f-c7ff96c415d7)

### 2.2 Опис на формата "Wordle"

Во новата форма се наоѓаат 5 редови од празни квадратчиња во кои се испишуваат буквите кои корисникот ги погодува. Под нив се наоѓа Label за буквите кои се преостанати, односно се тргнуваат буквите кои се погодени и ги нема во зборот, а во горниот десен агол се наоѓа тајмерот. 

Изглед на формата:


![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/8fd7c5e4-8fac-4911-930a-bec6812a70b5)

Ознаките на погодените букви се:
    - зелена боја - буквата ја има во зборот, на точно место 
    - жолта боја - буквата ја има во зборот, на друго место 
    - сива боја - буквата ја нема во зборот

### 2.3 Настани со кој се справува формата со прикажување на порака со MessageBox 

- притискање на копчето "Enter" без да е пополнет редот во кој се погодува

  
  ![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/5f691de6-c35a-4fdb-ae72-e202be967e9e)

- погодок на зборот


  ![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/b471ced0-0c4d-440a-921c-83acdb5161c0)

- изминато време


  ![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/a4882596-e14e-4b08-92fc-a49137c272f9)

  
- потрошени сите 5 обиди

  
  ![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/1748f698-7298-44e2-956d-66fe401b219d)

- притискање на буква пред да се кликне "Enter" при полн ред

  
 ![image](https://github.com/tkovachka/VP_Wordle/assets/107797831/ae6cf549-3775-48f7-ba88-eff19da8a9a8)

## 3. Опис на податоци, класи, функции

### Класа Dictionary 
- се чуваат 3 листи (со зборови од 5, 6 и 7 букви) од кои се бира некој збор на Random позиција

### Класа Square
- потребна за секое квадратче во кое се внесува буква
- се чува променлива Status за неговата состојба на почеток поставена на 0 (0=бело, 1=жолто, 2=зелено, 3=сиво)
- Draw метод кој во зависност од состојбата на квадратчето го бои во потребната боја
- метод за додавање на буква во него - void:AddLetter(string letter)

### Класа Word
- List<Square> Squares - се чува листа од квадратчиња, претставува еден ред во формата 
- променлива bool IsFull, иницијално поставена на false, која станува true кога ќе се исполни целата листа со букви (ред)
- во конструкторот на Word се дава точка за центар на првото квадратче, а потоа листата се пополнува со поместување на центарот на х-оската
- void Draw(Graphics g) метод во кој се повикува Draw за сите квадратчиња во редот
- void addLetter(string letter), во кој се додава буква во следното празно квадратче во редот, а доколку е последно, ја сетира променливата IsFull на true 
- public void checkLetters(string word) - при клик на ентер се повикува методот, ги проверува буквите со помош на менување на состојбата на сите квадратчиња во зависност од тоа дали се наоѓат во зборот и каде (имплементација и за дупликати на букви, односно доколку буквата се наоѓа во дадениот збор помалку пати отколку во погодениот збор, се бои само колку пати што ја има, а не повеќе)
- public bool IsCorrect() - враќа true само ако состојбата на сите квадратчиња е 2 (зелена боја)

### Класа Scene 
- List<Words> - се чува листа од 5 зборови кои ги претставуваат редовите
- Dictionary dictionary - објект од класата Dictionary кој се одбира со помош на Random објект во конструкторот на класата
- bool GameOver - се сетира на true при искористување на сите обиди/изминување на времето
- променлива bool full - станува true кога моменталниот ред во кој пишуваме е исполнет, а во спротива е false
- List<string> lettersGuessed - букви кои се погодувани 
- public string lettersLeft() со кој се одредуваат преостанатите букви за погодување (кои се наоѓаат во lettersGuessed)
- public bool Check() - го повикува методот checkLetters() за секој Word што е исполнет, а доколку стигнеме до последниот ред, ја променува вредноста на GameOver во false. Враќа true/false во зависност од тоа дали моменталниот збор кој се проверува е точен или не

### Форма Intro
- се справува само со клик на копчето Start, со тоа што ја отвара формата Wordle во која се наоѓаат сите податоци, а самата таа се затвара

### Форма Wordle
- 



