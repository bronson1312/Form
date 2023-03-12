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
        //������ ���������
        static List<List<int>> graf = new List<List<int>>()
            {
                //new List<int> {1, 4},
                //new List<int> {0, 2, 3, 4},
                //new List<int> {1, 3},
                //new List<int> {1, 2},
                //new List<int> {0, 1},

                new List<int> {1}, //���������������
                new List<int> {2, 4},
                new List<int> {3},
                new List<int> {1},
                new List<int> {0},
            };


        //������� ���������
        //1 ����� ����� � ������� ������� ���������
        public static List<int> result = new List<int>();
        static bool[] visited = new bool[6];
        static int[,] mat = new int[6, 6]{
                    {0, 1, 0, 0, 0, 0 },
                    {1, 0, 1, 1, 0, 0 },
                    {0, 1, 0, 0, 0, 0 },
                    {0, 1, 0, 0, 1, 1 },
                    {0, 0, 0, 1, 0, 0 },
                    {0, 0, 0, 1, 0, 0 }


            // { 0, 0, 1, 0},//��� 13 
            //{ 1, 0, 0, 0},
            //{ 0, 0, 0, 1},
            //{ 0, 1, 0, 0},

                //{0, 0, 0, 0, 0, 0, 0, 0 },//��� 4 ������ ����� 
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
        //1 ����� ����� ����� � ������� ������� ���������

        //2  ����� ����� � ������� ������ ���������
        struct VW
        {
            int v;//������� � ������� ���� �����
            int w;//��� �����
            public VW(int v, int w) //����������� ��� ������������� ����� ���������
            {
                this.v = v;
                this.w = w;
            }
            public int V { get { return v; } } //�������� ��� ��������� �������� ������� � ������� ���� �����
            public int W { get { return w; } } //�������� ��� ��������� ���� �����
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
        //2 ����� ����� ����� � ������� ������ ���������

        //3 ����� �������� ������ ����� � ������.
        public static Queue<int> shir = new Queue<int>();

        static int[] uses = new int[6];

        static object bfs3(int v)
        {
            shir.Enqueue(v); //��������� �������� ������� � �������
            uses[v] = 1; //������� �������� �� �� ����������
            while (shir.Count != 0)//���� ������� �� �����
            {
                int node = shir.Dequeue(); //���������� � node ������� � ������� �� ������� 
                uses[node] = 2;
                for (int i = 0; i < 6; i++)
                {
                    if (mat[node, i] != 0 && uses[i] == 0)// ���� ������� ������� � �� ����������
                    {
                        shir.Enqueue(i); //��������� � �������
                        uses[i] = 1; //������� �������� �� �� ����������
                    }
                }
                int a = node + 1; // ������� ����� ������� ������� ����������
                result.Add(a);
            }
            return result;
        }

        //3 ����� ����� �������� ������ ����� � ������.
        //4_��������������_����������
        static bool[] uses4 = new bool[8];
        static Stack<int> ans4 = new Stack<int>();
        static int[] color4 = new int[8];
            static bool ciclSearch4(int v) //�������� ����� �� �����������
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
            static void dfs4(int v) //����� � �������
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

            static object Tsort4() // �������������� ����������
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
                else MessageBox.Show("���� ����� ����, �������������� ���������� ����������");
                  return result;
            }


        //4 �����_��������������_����������


        //8_��������_����������_���������_������
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

            static bool svaz8() //�������� ����� �� ���������
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

            static bool checkEulerostOrientGraf8() //�������� ���������������� ����� �� ����������� ������: ���� ����� ������
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
            static bool checkEulerostNoOrientGraf8() //�������� ������������������ ����� �� ������� ��������� ������
            {
                if (svaz8() != false)
                {
                    int stepen;
                    for (int i = 0; i < 6; i++) //�������� �� �������� �������� ������
                    {
                        stepen = 0; //������� �������
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
                                mat[start, i] = 0; //������� ����� ������� ��������
                                //graf[i,start]=0; //���� ���� ���������������, �� ��� �������� �� �����
                                Way8.Add(i); //��������� � ������ ������
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
                    MessageBox.Show("� ���� ����� ��� �������� �����");
                }
                return result;
            }

        //����� 8_��������_����������_���������_������

        //9 ��������� ���� ������
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

            static bool svaz() //�������� ����� �� ���������
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

            static bool checkEulerostNoOrientGraf() //�������� ������������������ ����� �� ������� ��������� ������
            {
                if (svaz() != false)
                {
                    for (int i = 0; i < n; i++) //�������� �� �������� �������� ������
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
                if (checkEulerostOrientGraf() != false) //���� ���� �����������������
                                                        //���� ��������������� �� checkEulerostOrientGraf()
                {
                    while (graf[start].Count != 0)
                    {
                        sled = graf[start][0];
                        graf[start].Remove(sled); //������� ����� ������� ��������
                                                  //graf[sled].Remove(start); //���� ���� ���������������, �� ��� �������� �� �����
                        Way9.Add(sled); //��������� � ������ ������
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
                    MessageBox.Show("������! � ���� ����� ��� �������� �����");
                }
                return result;
            }
        
        //9 ����� ��������� ����

        //5 �������� ��������� ����� � ��� �����.
            static int[] color = new int[6]; //����� ������

            static int[,] SvazV = new int[6, 6]; //������ ������ ������ 
            static bool Dvudolniy = true;

            static void TwoColorDrawdfs(int v, int p) // p-���� ���������� �������
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
        //5 ����� �������� ��������� ����� � ��� �����.

        // 13 �������� ���������� ������������ �����
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

        // 13 ����� �������� ���������� ������������ �����



        //����� � ������� �� ������ ����������� ����� 
        private void button1_Click(object sender, EventArgs e)
        {
            textBoxOtvet.Clear();
            int TochkaA = Convert.ToInt32(textBox1.Text);

            //5 ����� ������������ ��������� ����� � ��� �����
            //for (int i = 0; i < 6; i++) //�������� ��������� �����
            //{
            //    for (int j = 0; j < 6; j++)
            //    {
            //        SvazV[i, j] = mat[i, j];
            //    }
            //}

            //for (int i = 0; i < 6; i++) //���������� ������������ �����
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
            //else MessageBox.Show("���� �� ����������");
            //5 ����� ������ ������������ ��������� ����� � ��� �����

            //13 �������� ���������� ������������ �����
                
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
                //else MessageBox.Show("��� ������������ �����");
            //13 ����� �������� ���������� ������������ �����


            /* result = (List<int>)DFS_Obhod_V_Glubinu(TochkaA);*/ // 1 ����� � �������
            //result = (List<int>)bfs3(TochkaA); //����� 3
            /* result = (List<int>)EulerCicle8(TochkaA);*/    //8 ����� 
            //Tsort4(); //������ 4 ������ �� �������� ������� ����� ���� 



            for (int i = 0; i < result.Count; i++)
            {
                textBoxOtvet.Text += result[i].ToString() + " ";
                
            }

            //string path1 = @"C:\Visual\WinFormsApp2\WinFormsApp2\bin\result.txt";
            string path1 = @"result.txt";
            var lines = File.ReadAllLines(path1).ToList();
            File.WriteAllLines(path1, result.ConvertAll(x => x.ToString()));

        }
        //����� ����� �� ����� ������� ��������� 
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = 6;
            for (int i = 0; i < 6; ++i)
                for (int j = 0; j < 6; ++j)
                    dataGridView1.Rows[i].Cells[j].Value = mat[i, j];
        }

        //������ ����� ��������
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
        //����� ������� ����� ��������

        //����� ����� �� ����� ������ ��������� 
        private void buttonSpisok_Click(object sender, EventArgs e)
        {
            //��� 9 ������
            dataGridView1.RowCount = 5;//������
            dataGridView1.ColumnCount = 2;//�������
           

            for (int i = 0; i < 5; i++)//������ �� ������� ����� ������� 5
            {
                for (int j = 0; j < graf2[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = graf2[i][j].V;
                    
                }
            }

        }
        //����� � ���� ������ � ������ � ������ ��������� ������
        private void buttonEilerVicheclit_Click(object sender, EventArgs e)
        {
            textBoxOtvet.Clear();
            int Tochka = Convert.ToInt32(textBoxEiler.Text);
            
            //result = (List<int>) EulerCicle(Tochka); // 9 �����
            //result = (List<int>)dfs2(Tochka);   //2 ����� 

            for (int i = 0; i < result.Count; i++)
            {
                textBoxOtvet.Text += result[i].ToString() + " ";

            }

            //������ � ����
            string path1 = @"result.txt";
            var lines = File.ReadAllLines(path1).ToList();
            File.WriteAllLines(path1, result.ConvertAll(x => x.ToString()));


        }
    }
}