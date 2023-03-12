using System.Collections.Generic;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Список Смежности
        static List<List<int>> graf = new List<List<int>>()
            {
                //new List<int> {1, 4},
                //new List<int> {0, 2, 3, 4},
                //new List<int> {1, 3},
                //new List<int> {1, 2},
                //new List<int> {0, 1},

                new List<int> {1}, //ориентированный
                new List<int> {2, 4},
                new List<int> {3},
                new List<int> {1},
                new List<int> {0},
            };


        //Матрциа Смежности
        //1 Обход Графа В глубину Матрица Смежности
        public static List<int> result = new List<int>();
        static bool[] visited = new bool[6];
        static int[,] mat = new int[6, 6]{
                    {0, 1, 0, 0, 0, 0 },
                    {1, 0, 1, 1, 0, 0 },
                    {0, 1, 0, 0, 0, 0 },
                    {0, 1, 0, 0, 1, 1 },
                    {0, 0, 0, 1, 0, 0 },
                    {0, 0, 0, 1, 0, 0 }


            // { 0, 0, 1, 0},//для 13 
            //{ 1, 0, 0, 0},
            //{ 0, 0, 0, 1},
            //{ 0, 1, 0, 0},

                //{0, 0, 0, 0, 0, 0, 0, 0 },//для 4 билета нужна 
                //{1, 0, 0, 0, 0, 0, 0, 0 },
                //{0, 1, 0, 1, 0, 0, 1, 0 },
                //{0, 0, 0, 0, 1, 0, 0, 0 },
                //{0, 0, 0, 0, 0, 1, 0, 0 },
                //{0, 0, 0, 0, 0, 0, 0, 0 },
                //{0, 0, 0, 0, 1, 0, 0, 0 },
                //{ 0, 0, 1, 0, 0, 0, 0, 0 }
            };

        public static object DFS_Obhod_V_Glubinu(int v)
        {
            int a = v + 1;
            result.Add(a);
            visited[v] = true;
            for (int j = 0; j < 6; j++)
            {
                if (mat[v, j] != 0 && visited[j] == false) DFS_Obhod_V_Glubinu(j);
            }
            return result;
        }
        //1 Конец Обход Графа В глубину Матрица Смежности

        //2  Обход Графа В глубину Список Смежности
        struct VW
        {
            int v;//вершина в которую идет ребро
            int w;//вес ребра
            public VW(int v, int w) //конструктор для инициализации полей структуры
            {
                this.v = v;
                this.w = w;
            }
            public int V { get { return v; } } //свойства для получения значения вершины в которую идет ребро
            public int W { get { return w; } } //свойство для получения веса ребра
        }

        static bool[] visited2 = new bool[5];
        static List<List<VW>> graf2 = new List<List<VW>>{
                    new List<VW>{new VW(1, 1)},
                    new List<VW>{new VW(2, 2)},
                    new List<VW>{new VW(3, 3)},
                    new List<VW>{new VW(1, 4)},
                    new List<VW>{new VW(0, 3), new VW(1, 7)}
                 };
        static object dfs2(int v)
        {
            int a = v + 1;
            result.Add(a);
            visited2[v] = true;
            for (int j = 0; j < graf2[v].Count; j++)
            {
                if (visited2[graf2[v][j].V] != true)
                {
                    dfs2(graf2[v][j].V);
                }
            }
            return result;
        }
        //2 Конец Обход Графа В глубину Список Смежности

        //3 Билет Алгоритм обхода графа в ширину.
        public static Queue<int> shir = new Queue<int>();

        static int[] uses = new int[6];

        static object bfs3(int v)
        {
            shir.Enqueue(v); //добавляем исходную вершину в очередь
            uses[v] = 1; //вершина посещена но не обработана
            while (shir.Count != 0)//пока очередь не пуста
            {
                int node = shir.Dequeue(); //записываем в node элемент и удаляем из очереди 
                uses[node] = 2;
                for (int i = 0; i < 6; i++)
                {
                    if (mat[node, i] != 0 && uses[i] == 0)// если вершина смежная и не посещенная
                    {
                        shir.Enqueue(i); //добавляем в очередь
                        uses[i] = 1; //вершина посещена но не обработана
                    }
                }
                int a = node + 1; // выводим номер вершины которую обработали
                result.Add(a);
            }
            return result;
        }

        //3 Конец Билет Алгоритм обхода графа в ширину.
        //4_топологическая_сортировка
        static bool[] uses4 = new bool[8];
        static Stack<int> ans4 = new Stack<int>();
        static int[] color4 = new int[8];
            static bool ciclSearch4(int v) //проверка графа на цикличность
            {
                color4[v] = 1;
                for (int i = 0; i < 8; i++)
                {
                    if (mat[v, i] != 0)
                    {
                        if (color4[i] == 0)
                        {
                            if (ciclSearch4(i)) return true;
                        }
                        else if (color4[i] == 1)
                        {
                            return true;
                        }
                    }
                }
                color4[v] = 2;
                return false;
            }
            static void dfs4(int v) //обход в глубину
            {
                uses4[v] = true;
                for (int i = 0; i < 8; i++)
                {
                    if (mat[v, i] != 0 && uses4[i] != true)
                    {
                        dfs4(i);
                    }
                }
                ans4.Push(v);
            }

            static object Tsort4() // топологическая сортировка
            {
                bool cicleGraf = false;
                for (int i = 0; i < 8; i++)
                {
                    if (ciclSearch4(i))
                    {
                        cicleGraf = true;
                    }
                }
                if (cicleGraf != true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (uses4[i] != true)
                        {
                            dfs4(i);
                        }
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        int a = ans4.Peek() + 1;
                        ans4.Pop();
                        result.Add(a);
                    }
                }
                else MessageBox.Show("Граф имеет цикл, топологическая сортировка невозможна");
                  return result;
            }


        //4 Конец_топологическая_сортировка


        //8_алгоритм_нахождения_эйлеровых_циклов
            static void dfs8(int v)
            {
                visited[v] = true;
                for (int i = 0; i < 6; i++)
                {
                    if (visited[i] != true && mat[v, i] != 0)
                    {
                        dfs8(i);
                    }
                }
            }

            static bool svaz8() //проверка графа на связность
            {
                dfs8(0);
                for (int j = 0; j < 6; j++)
                {
                    if (visited[j] != true)
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool checkEulerostOrientGraf8() //проверка ориентированного графа на Ейлеровость должно: вход равен выходу
            {
                int vhod, vihod; ;
                for (int i = 0; i < 6; i++)
                {
                    vhod = 0;
                    vihod = 0;
                    for (int j = 0; j < 6; j++)
                    {
                        if (mat[i, j] != 0)
                        {
                            vihod++;
                        }
                        if (mat[j, i] != 0)
                        {
                            vhod++;
                        }
                    }
                    if (vhod != vihod)
                    {
                        return false;
                    }
                }
                return true;
            }
            static bool checkEulerostNoOrientGraf8() //проверка неориентированного графа на наличие эйлеровых циклов
            {
                if (svaz8() != false)
                {
                    int stepen;
                    for (int i = 0; i < 6; i++) //проверка на четность степеней вершин
                    {
                        stepen = 0; //степень вершины
                        for (int j = 0; j < 6; j++)
                        {
                            if (mat[i, j] != 0)
                            {
                                stepen++;
                            }
                        }
                        if (stepen % 2 == 1)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else return false;
            }

            static object EulerCicle8(int start)
            {
                bool end = false;
                int countZero = 0;
                List<int> Way8 = new List<int>();
                Way8.Add(start);
                if (checkEulerostOrientGraf8() != false)
                {
                    while (!end)
                    {
                        countZero = 0;
                        for (int i = 0; i < 6; i++)
                        {

                            if (mat[start, i] != 0)
                            {
                                mat[start, i] = 0; //стираем ребро которое посетили
                                //graf[i,start]=0; //если граф ориентированный, то это действие не нужно
                                Way8.Add(i); //добавляем в список вершин
                                start = i;
                                break;
                            }
                            else countZero++;
                        }
                        if (countZero == 6)
                        {
                            end = true;
                        }
                    }
                
                    for (int i = 0; i < Way8.Count; i++)
                    {
                    int Otvet = Way8[i] + 1;
                    result.Add(Otvet);
                    }
                }
                else
                {
                    MessageBox.Show("В этом графе нет эйлерова цикла");
                }
                return result;
            }

        //Конец 8_алгоритм_нахождения_эйлеровых_циклов

        //9 Эйлеровый Цикл Начало
             const int n = 5;
            static bool[] visited9 = new bool[n];

            static void dfs(int v)
            {
                visited9[v] = true;
                for (int j = 0; j < graf[v].Count; j++)
                {
                    if (visited9[graf[v][j]] != true)
                    {
                        dfs(graf[v][j]);
                    }
                }
            }

            static bool svaz() //проверка графа на связность
            {
                dfs(0);
                for (int j = 0; j < n; j++)
                {
                    if (visited9[j] != true)
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool checkEulerostOrientGraf()
            {
                int vhod, vihod;
                for (int j = 0; j < n; j++)
                {
                    vhod = 0;
                    vihod = graf[j].Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (graf[i].Contains(j))
                        {
                            vhod++;
                        }
                    }
                    if (vhod != vihod)
                    {
                        return false;
                    }
                }
                return true;
            }

            static bool checkEulerostNoOrientGraf() //проверка неориентированного графа на наличие эйлеровых циклов
            {
                if (svaz() != false)
                {
                    for (int i = 0; i < n; i++) //проверка на четность степеней вершин
                    {
                        if (graf[i].Count % 2 == 1)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else return false;
            }

            static object EulerCicle(int start)
            {
                List<int> Way9 = new List<int>();
                int sled;
                Way9.Add(start);
                if (checkEulerostOrientGraf() != false) //если граф неориентированный
                                                        //если ориентированный то checkEulerostOrientGraf()
                {
                    while (graf[start].Count != 0)
                    {
                        sled = graf[start][0];
                        graf[start].Remove(sled); //стираем ребро которое посетили
                                                  //graf[sled].Remove(start); //если граф ориентированный, то это действие не нужно
                        Way9.Add(sled); //добавляем в список вершин
                        start = sled;
                    }
                
                    for (int i = 0; i < Way9.Count; i++)
                    {
                       int a = Way9[i] + 1;
                       result.Add(a);
                    }
                }
                else
                {
                    MessageBox.Show("ОШИБКА! В этом графе нет эйлерова цикла");
                }
                return result;
            }
        
        //9 Конец Эйлеровый цикл

        //5 Алгоритм раскраски графа в два цвета.
            static int[] color = new int[6]; //цвета вершин

            static int[,] SvazV = new int[6, 6]; //массив связей вершин 
            static bool Dvudolniy = true;

            static void TwoColorDrawdfs(int v, int p) // p-цвет предыдущей вершины
            {
                color[v] = p;
                for (int i = 0; i < 6; i++)
                {
                    if (SvazV[v, i] == 1)
                    {
                        if (color[i] == 0)
                        {
                            TwoColorDrawdfs(i, -p);
                        }
                        else if (color[i] == color[v])
                        {
                            Dvudolniy = false;
                            return;
                        }
                    }
                }
            }
        //5 Конец Алгоритм раскраски графа в два цвета.

        // 13 Алгоритм нахождения Гамильтового цикла
        static int[] Way13 = new int[5] { -1, -1, -1, -1, -1,};
        static bool[] visited13 = new bool[4];

        static void Solve(int v, int Count)
        {
         
            visited13[v] = true; Way13[Count] = v;
            
            for (int i = 0; i < 4; i++)
                if (mat[v, i] != 0)
                {
                    if (visited13[i] == false)
                        Solve(i, Count + 1);
                }
           
            visited13[v] = false;
            
        }

        // 13 Конец Алгоритм нахождения Гамильтового цикла



        //Обход в глубину по кнопке заполенение файла 
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxOtvet.Clear();
            int TochkaA = Convert.ToInt32(textBox1.Text);

            //5 Вызов РадуАлгоритм раскраски графа в два цвета
            //for (int i = 0; i < 6; i++) //копируем имеющиеся связи
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        SvazV[i, j] = mat[i, j];
            //    }
            //}

            //for (int i = 0; i < 6; i++) //записываем двустороннюю связь
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        if (SvazV[i, j] == 1)
            //        {
            //            SvazV[i, j] = 1;
            //            SvazV[j, i] = 1;
            //        }

            //    }

            //}
            //TwoColorDrawdfs(TochkaA, 1);
            // int a, b;
            //if (Dvudolniy == true)
            //{
            //    for (int i = 0; i < n; i++)
            //    {
            //        a = i + 1;
            //        b = color[i];
            //        result.Add(a);
            //        result.Add(b);
            //    }
            //}
            //else MessageBox.Show("Граф не двудольный");
            //5 Конец ВЫзова РадуАлгоритм раскраски графа в два цвета

            //13 Алгоритм нахождения Гамильтового цикла
                
                //Solve(TochkaA, 0);
                //bool flag = true;
                //if (Way13[4 - 1] >= 0 && mat[Way13[4 - 1], TochkaA] == 1)
                //{
                //    Way13[4] = TochkaA;
                //}
                //else flag = false;
                //if (flag)
                //{
                //    for (int i = 0; i < 4 + 1; i++)
                //    {
                //        int a = Way13[i];
                //        result.Add(a);
                //    }
                //}
                //else MessageBox.Show("нет гамильтонова цикла");
            //13 Конец Алгоритм нахождения Гамильтового цикла


            /* result = (List<int>)DFS_Obhod_V_Glubinu(TochkaA);*/ // 1 Обход в глубину
            //result = (List<int>)bfs3(TochkaA); //билет 3
            /* result = (List<int>)EulerCicle8(TochkaA);*/    //8 билет 
            //Tsort4(); //билете 4 ничего не передаем удаляем текст бокс 



            for (int i = 0; i < result.Count; i++)
            {
                textBoxOtvet.Text += result[i].ToString() + " ";
                
            }

            //string path1 = @"C:\Visual\WinFormsApp2\WinFormsApp2\bin\result.txt";
            string path1 = @"result.txt";
            var lines = File.ReadAllLines(path1).ToList();
            File.WriteAllLines(path1, result.ConvertAll(x => x.ToString()));

        }
        //Вывод графа на форму Матрица смежности 
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 6;
            for (int i = 0; i < 6; ++i)
                for (int j = 0; j < 6; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = mat[i, j];
        }

        //запрет ввода символов
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        private void textBoxEiler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) return;
            else
                e.Handled = true;
        }
        //Конец Запрета ввода Символов

        //Вывод графа на форму Список смежности 
        private void buttonSpisok_Click(object sender, EventArgs e)
        {
            //Для 9 Список
            dataGridView1.RowCount = 5;//строки
            dataGridView1.ColumnCount = 2;//столбцы
           

            for (int i = 0; i < 5; i++)//Массив из сколько строк состоит 5
            {
                for (int j = 0; j < graf2[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = graf2[i][j].V;
                    
                }
            }

        }
        //Вывод В файл ответа и Запуск в кнопке алгоритма Эйлера
        private void buttonEilerVicheclit_Click(object sender, EventArgs e)
        {
            textBoxOtvet.Clear();
            int Tochka = Convert.ToInt32(textBoxEiler.Text);
            
            //result = (List<int>) EulerCicle(Tochka); // 9 Билет
            //result = (List<int>)dfs2(Tochka);   //2 билет 

            for (int i = 0; i < result.Count; i++)
            {
                textBoxOtvet.Text += result[i].ToString() + " ";

            }

            //Запись в файл
            string path1 = @"result.txt";
            var lines = File.ReadAllLines(path1).ToList();
            File.WriteAllLines(path1, result.ConvertAll(x => x.ToString()));


        }
    }
}