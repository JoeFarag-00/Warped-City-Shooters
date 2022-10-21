using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace BigGame___WarpedCity
{
    public class StartScreen
    {
        public int X_Title, Y_Title;
        public Bitmap Title_img;
        public int Title_Width, Title_Height;

        public int X_SBG, Y_SBG;
        public Bitmap Start_Background_img;
        public int SBG_Width, SBG_Height;

        public int X_Ins, Y_Ins;
        public Bitmap Instructions_img;
        public int SIns_Width, SIns_Height;

    }
    public class StartScreen_EnterBTN
    {
        public int X_SB, Y_SB;
        public Bitmap Start_Btn_img;
        public int SBTN_Width, SBTN_Height;
    }

    public class SFX
    {
        public SoundPlayer[] Track = new SoundPlayer[4];
        public int TF = 0;
    }

    public class BackgroundMAP
    {
        public Rectangle rcDst = new Rectangle();
        public Rectangle rcSrc = new Rectangle();
        public Bitmap BackgroundMap_img;
    }

    public class BackgroundVehicles
    {
        public int R_Vframe = 0, L_VFrame = 0, SpawnLeft, SpawnRight;
        public Rectangle[] rcDst = new Rectangle[2];
        public Rectangle[] rcSrc = new Rectangle[2];
        public Bitmap L_Vehicle_img;
        public Bitmap R_Vehicle_img;
    }
    
    public class Building
    {
        public int BFrame = 0;
        public Rectangle rcDst = new Rectangle();
        public Rectangle rcSrc = new Rectangle();
        public Bitmap Building_img;
    }

    public class BuildingBanners
    {
        public Rectangle[] rcDst = new Rectangle[6];
        public Rectangle[] rcSrc = new Rectangle[6];
        public Bitmap[] Banner_img = new Bitmap[6];
    }

    public class Hero
    {
        public int Hero_Status = 0;
        public int Hero_Status_Dir = 0;

        public Rectangle[] rcDst = new Rectangle[8];
        public Rectangle[] rcSrc = new Rectangle[8];

        public int R_IdleFrames = 0, L_IdleFrames = 0;
        public Bitmap[] R_IdleHero_img = new Bitmap[4];
        public Bitmap[] L_IdleHero_img = new Bitmap[4];

        public int R_RunFrames = 0, L_RunFrames = 0;
        public Bitmap[] R_HeroRun_img = new Bitmap[8];
        public Bitmap[] L_HeroRun_img = new Bitmap[8];

        public int R_ShootFrames = 0, L_ShootFrames = 0;
        public Bitmap R_HeroShoot_img;
        public Bitmap L_HeroShoot_img;

        public int R_RunShootFrames = 0, L_RunShootFrames = 0;
        public Bitmap[] R_HeroRunShoot_img = new Bitmap[8];
        public Bitmap[] L_HeroRunShoot_img = new Bitmap[8];

        public int R_JumpFrames = 0, L_JumpFrames = 0;
        public Bitmap[] R_HeroJump_img = new Bitmap[4];
        public Bitmap[] L_HeroJump_img = new Bitmap[4];

        public int R_CrouchFrames = 0, L_CrouchFrames = 0;
        public Bitmap R_HeroCrouch_img;
        public Bitmap L_HeroCrouch_img;

        public int R_HurtFrames = 0, L_HurtFrames = 0;
        public Bitmap R_HeroHurt_img;
        public Bitmap L_HeroHurt_img;

        public int HeroClimb_Frames = 0;
        public Bitmap[] Hero_Climb = new Bitmap[5];


        public int Run_Speed;
        public int Jump_Speed;
        public int Climb_Speed;
        public int Shoot_Speed;
    }
    public class WeaponShot
    {
        public int Hero_Status_Dir = 0;
        public int R_ShotFrames = 0, L_ShotFrames = 0;
        public Rectangle[] rcDst = new Rectangle[3];
        public Rectangle[] rcSrc = new Rectangle[3];
        public Bitmap[] R_WeaponShot_img = new Bitmap[3];
        public Bitmap[] L_WeaponShot_img = new Bitmap[3];
    }

    public class EDrone
    {
        public int EDrone_Status = 0, EDrone_Status_Dir = 0;
        public int RFrame = 0, LFrame = 0, EDroneExpFrame = 0;
        public Rectangle[] rcDst = new Rectangle[3];
        public Rectangle[] rcSrc = new Rectangle[3];
        public Bitmap R_EDrone_img;
        public Bitmap L_EDrone_img;

        public Bitmap[] EDroneExp_img = new Bitmap[6];
        public int Roam_Speed;
        public int Shoot_Speed;
    }

    public class ETurret
    {
        public int Eturret_Status = 0;
        public int EturretFrame = 0, ETurretExpFrame;
        public Rectangle[] rcDst = new Rectangle[3];
        public Rectangle[] rcSrc = new Rectangle[3];
        public Bitmap[] ETurret_img = new Bitmap[6];
        public Bitmap[] ETurretExp_img = new Bitmap[6];

    }
    public class ETurretShot
    {
        public int Shot_Dir = 0;
        public int R_ShotFrames = 0, L_ShotFrames = 0;
        public Rectangle[] rcDst = new Rectangle[3];
        public Rectangle[] rcSrc = new Rectangle[3];
        public Bitmap[] R_WeaponShot_img = new Bitmap[3];
        public Bitmap[] L_WeaponShot_img = new Bitmap[3];
    }

    public partial class Form1 : Form
    {
        Bitmap off;
        List<StartScreen> LStarts = new List<StartScreen>();
        List<StartScreen_EnterBTN> LEnters = new List<StartScreen_EnterBTN>();
        List<Building> LBuildings = new List<Building>();
        List<BackgroundMAP> LBGs = new List<BackgroundMAP>();
        List<BackgroundVehicles> LVehicles = new List<BackgroundVehicles>();
        List<BuildingBanners> LBanners = new List<BuildingBanners>();
        List<Hero> LHeros = new List<Hero>();
        List<WeaponShot> LShots = new List<WeaponShot>();
        List<EDrone> LEDrones = new List<EDrone>();
        List<ETurret> LETurrets = new List<ETurret>();
        List<ETurretShot> LETurretsShots = new List<ETurretShot>();
        List<SFX> LTracks = new List<SFX>();
        Timer Pulse = new Timer();
        Random Random = new Random();
        int StartTimeHlt = 0;
        int HeroTimeHlt = 0;
        int MapGenTimeHlt = 0;
        int RenderBuildSpeed = 0;
        int RVSpeed = 0;
        int LVSpeed = 0;
        int SpaceBuilds = 0;
        int MoreSpace = 0;
        int Ebtnstate = 0;
        bool IdleStatus = true;
        bool RunStatus = false;
        bool CrouchStatus = false;
        int CreateRunOnce = 0;
        bool GameStartStatus = false;
        bool CreateBuilds = false;
        bool NotAgain = false;
        bool Isstand = false;
        bool HitLadder;
        int currpos_X = 0, currpos_Y = 0;
        bool LiftD = false;
        bool LiftA = false;
        bool LiftS = false;
        bool LiftW = false;
        bool LiftE = false;
        bool LiftSpace = false;
        bool FirstBuild = false;
        bool StartBuilding = false;
        bool DoneClimb = false;
        bool ShootWeaponRight = false;
        bool ShootWeaponLeft = false;
        int CamX = 0, CamY = 0;
        int CamXFlag = 0;
        bool ComboES = false;
        bool bgMusic = false;
        bool ShootSFX = false;
        bool ExpSFX = false;

        //Spawn Cycles
        bool Spawn1 = false;
        bool Spawn2 = false;
        bool Spawn3 = false;
        bool Spawn4 = false;
        bool Spawn5 = false;
        bool Spawn6 = false;

        int test = 0;
        int testct = 0;

        int CtScore = 0;
        int CtRight = 5;
        int CtLeft = 0;

        int IWhichT = -1;
        int IWhichD = -1;
        int IWhichB = -1;

        int spray = 0;
        bool givetime = false;

        int CtJump = 0;
        bool IsJump = false;
        bool done = false;
        int OldY = 0;
        bool gameover = false;

        //Animation Values
        public int HoverUp1 = 0;
        public int HoverUp2 = 0;
        public int HoverDown1 = 0;
        public int HoverDown2 = 0;


        public Form1()
        {
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            Pulse.Tick += Generate_GameTicks;
            Pulse.Start();
            Pulse.Interval = 65;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            Create_StartScreen();


        }
        public void LaunchGame()
        {
            CreateBuilds = true;

            Create_Hero_States();


            CreateMap_Background();

        }
        public void Generate_GameTicks(object sender, EventArgs e)
        {
            if (!GameStartStatus)
            {
                if (StartTimeHlt % 20 == 0)
                {
                    Ebtnstate = 0;
                    if (Ebtnstate == 0)
                    {
                        Create_EnterBTN_StartScreen();
                    }
                }

                Ebtnstate = 1;

                if (StartTimeHlt % 40 == 0)
                {
                    if (Ebtnstate == 1)
                    {
                        RemoveEnterButton();
                    }
                }
            }

            if (GameStartStatus)
            {
                if (MapGenTimeHlt % 30 == 0)
                {
                    CreateVehicles_Background();

                }
                AnimateVehicles_Background_Right();
                AnimateVehicles_Background_Left();
            }

            Automate_Building_Creation();

            if (MapGenTimeHlt % 60 == 0)
            {
                Animate_Turrets(1);
            }
            if (MapGenTimeHlt % 10 == 0)
            {
                Animate_Turrets(2);
            }


            if (HeroTimeHlt % 3 == 0)
            {
                if (GameStartStatus)
                {
                    Animate_IdleHero_Right();
                    Animate_IdleHero_Left();
                }
            }

            MoveCamX();
            Animate_ShootHero_Right();

            for (int i = 0; i < LShots.Count; i++)
            {
                if (LShots[i].Hero_Status_Dir == 1)
                {
                    LShots[i].rcDst[0].X += 20;
                    if (LShots[i].R_ShotFrames < 1)
                    {
                        LShots[i].R_ShotFrames++;
                    }
                    else
                    {
                        LShots[i].R_ShotFrames = 0;
                    }

                }




                if (LShots[i].Hero_Status_Dir == 2)
                {
                    LShots[i].rcDst[1].X -= 20;

                    if (LShots[i].L_ShotFrames < 1)
                    {
                        LShots[i].L_ShotFrames++;
                    }
                    else
                    {
                        LShots[i].L_ShotFrames = 0;
                    }
                }
            }

            if (HeroTimeHlt % 10 == 0)
            {
                Animate_EDrone();
            }

            IWhichT = Hit_EnemyTurret();
            if (IWhichT != -1)
            {
                LETurrets.Remove(LETurrets[IWhichT]);
            }

            IWhichD = Hit_EnemyDrone();
            if (IWhichD != -1)
            {
                LEDrones.Remove(LEDrones[IWhichD]);
            }


            if (HeroTimeHlt % 2 == 0)
            {
                if (IWhichB != -1)
                {
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        LHeros[i].rcDst[0].Y -= 4;

                    }
                }
            }

            if (RunStatus == true)
            {

            }

            if (CreateBuilds)
            {
                /* Automate_Building_Creation();*/
            }

           /* CreateEnemyWeaponShot(Random.Next(1, 2));*/
            for (int i = 0; i < LETurretsShots.Count; i++)
            {
                LETurretsShots[i].rcDst[0].X += 20;
                LETurretsShots[i].rcDst[0].Y += 20;
            }

            StartTimeHlt += 2;
            HeroTimeHlt += 2;
            MapGenTimeHlt += 2;
            RenderBuildSpeed += 2;
            //Jump
            if (CtJump > 0)
            {
                if (IsJump)
                {
                    Animate_JumpingHero_Left();
                    Animate_JumpingHero_Right();
                }




                CtJump--;

            }
            if (!done)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    for (int j = 0; j < LHeros.Count; j++)
                    {
                        if (LHeros[i].rcDst[j].Y >= ClientSize.Height)
                        {
                            if (!gameover)
                            {
                                MessageBox.Show("Game Over");
                                gameover = true;
                            }
                            done = false;
                        }
                    }

                }
            }


            DrawDubb();
        }


        public void Create_StartScreen()
        {
            //Background
            StartScreen pnn = new StartScreen();
            pnn.Start_Background_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//StartScreen//MBG2.png");
            pnn.SBG_Width = pnn.Start_Background_img.Width;
            pnn.SBG_Height = pnn.Start_Background_img.Height;
            pnn.X_SBG = 0;
            pnn.Y_SBG = 0;

            //Title
            pnn.Title_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//StartScreen//title-screen.png");
            pnn.Title_Width = pnn.Title_img.Width + 210;
            pnn.Title_Height = pnn.Title_img.Height + 100;
            pnn.X_Title = ((ClientSize.Width / 2) - 220);
            pnn.Y_Title = (ClientSize.Height / 3);

            LStarts.Add(pnn);


            SFX mpnn = new SFX();
            mpnn.Track[0] = new SoundPlayer(@"C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Sounds//Intro1.wav");
            mpnn.Track[0].PlayLooping();
        }

        public void Create_EnterBTN_StartScreen()
        {
            //Press Enter Button is in TimeTick
            StartScreen_EnterBTN pnn = new StartScreen_EnterBTN();
            pnn.Start_Btn_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//StartScreen//press-enter.png");
            pnn.SBTN_Width = pnn.Start_Btn_img.Width + 220;
            pnn.SBTN_Height = pnn.Start_Btn_img.Height + 20;
            pnn.X_SB = (ClientSize.Width / 2) - 200;
            pnn.Y_SB = (ClientSize.Height / 3) + 200;
            LEnters.Add(pnn);
        }

        public void RemoveEnterButton()
        {
            while (LEnters.Count > 0)
            {
                LEnters.RemoveAt(0);
            }
        }

        public void RemoveStartScreen()
        {
            while (LStarts.Count > 0)
            {
                LStarts.RemoveAt(0);
            }
            while (LEnters.Count > 0)
            {
                LEnters.RemoveAt(0);
            }
            SFX mpnn = new SFX();
            mpnn.Track[0] = new SoundPlayer(@"C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Sounds//Intro1.wav");
            mpnn.Track[0].Stop();
        }

        public void CreateMap_Background()
        {
            BackgroundMAP BG = new BackgroundMAP();
            BG.BackgroundMap_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//BackgroundMAP//LBGM-1.png");
            BG.rcDst = new Rectangle(BG.rcDst.X, BG.rcDst.Y, BG.BackgroundMap_img.Width, BG.BackgroundMap_img.Height - 230);
            BG.rcSrc = new Rectangle(0, 0, BG.BackgroundMap_img.Width, BG.BackgroundMap_img.Height);
            LBGs.Add(BG);
        }
        public void CreateVehicles_Background()
        {
            //Going Right
            BackgroundVehicles BG_Vehicles = new BackgroundVehicles();
            BG_Vehicles.SpawnLeft = Random.Next(220, ClientSize.Height - 80);
            BG_Vehicles.SpawnRight = Random.Next(220, ClientSize.Height - 80);
            BG_Vehicles.R_Vframe = Random.Next(1, 5);
            BG_Vehicles.R_Vehicle_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//BackgroundMAP//vehicles//Right//V-" + BG_Vehicles.R_Vframe + ".png");
            BG_Vehicles.rcDst[0] = new Rectangle(0, BG_Vehicles.SpawnLeft, BG_Vehicles.R_Vehicle_img.Width, BG_Vehicles.R_Vehicle_img.Height);
            BG_Vehicles.rcSrc[0] = new Rectangle(0, 0, BG_Vehicles.R_Vehicle_img.Width, BG_Vehicles.R_Vehicle_img.Height);
            LVehicles.Add(BG_Vehicles);

            //Going Left
            BG_Vehicles.L_VFrame = Random.Next(1, 5);
            BG_Vehicles.L_Vehicle_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//BackgroundMAP//vehicles//Left//V-" + BG_Vehicles.L_VFrame + ".png");
            BG_Vehicles.rcDst[1] = new Rectangle(ClientSize.Width, BG_Vehicles.SpawnRight, BG_Vehicles.L_Vehicle_img.Width, BG_Vehicles.L_Vehicle_img.Height);
            BG_Vehicles.rcSrc[1] = new Rectangle(0, 0, BG_Vehicles.L_Vehicle_img.Width, BG_Vehicles.L_Vehicle_img.Height);
            LVehicles.Add(BG_Vehicles);

        }

        public void AnimateVehicles_Background_Right()
        {
            /*RVSpeed = Random.Next(5, 25);*/
            for (int i = 0; i < LVehicles.Count; i++)
            {
                LVehicles[i].rcDst[0].X += 20;
            }

        }

        public void AnimateVehicles_Background_Left()
        {
            /* LVSpeed = Random.Next(5, 25);*/
            for (int i = 0; i < LVehicles.Count; i++)
            {
                LVehicles[i].rcDst[1].X -= 20;
            }

        }

        public void CreateMap_Buildings()
        {
            //Feed Building in list
            Building Build = new Building();
            Build.BFrame = Random.Next(1, 7);
            /*test = 6;*/

            Build.Building_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Obstacles//Buildings//Building-" + Build.BFrame + ".png");
            /* Build.Building_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Obstacles//Buildings//Building-"+test+".png");*/
            if (LBuildings.Count > 0)
            {
                int StartRangeX = LBuildings[LBuildings.Count - 1].rcDst.X + LBuildings[LBuildings.Count - 1].rcDst.Width;
                int EndRangeX = LBuildings[LBuildings.Count - 1].rcDst.X + LBuildings[LBuildings.Count - 1].rcDst.Width;
                MoreSpace = Random.Next(StartRangeX, EndRangeX);
            }

            SpaceBuilds = Build.rcDst.X + Build.rcDst.Width + 130;
            //Spawn Location in every building
            if (!FirstBuild)
            {
                Build.rcDst = new Rectangle(20, (ClientSize.Height - Build.Building_img.Height) - 250, Build.Building_img.Width + 220, Build.Building_img.Height + 250);
                FirstBuild = true;
                Isstand = true;
            }
            else
            {
                Build.rcDst = new Rectangle(SpaceBuilds + MoreSpace, (ClientSize.Height - Build.Building_img.Height) - 250, Build.Building_img.Width + 250, Build.Building_img.Height + 250);
            }
            if (Build.BFrame == 1 || test == 1)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 248;
                        }
                    }

                }
                Create_ETurrets(Build.rcDst.X + 250, Build.rcDst.Y + 30);
                Create_EDrone(Build.rcDst.X + 330, Build.rcDst.Y + 260, 0, 2);

            }
            if (Build.BFrame == 2 || test == 2)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 250;
                        }
                    }

                }
                Create_ETurrets(Build.rcDst.X + 80, Build.rcDst.Y + 30);
                Create_EDrone(Build.rcDst.X + 60, Build.rcDst.Y + 260, 0, 1);

            }
            if (Build.BFrame == 3 || test == 3)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 110;

                        }
                    }

                }
                Create_EDrone(Build.rcDst.X + 350, Build.rcDst.Y + 10, 0, 1);
                Create_ETurrets(Build.rcDst.X + 420, Build.rcDst.Y + 420);
            }

            if (Build.BFrame == 4 || test == 4)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 110;

                        }
                    }


                }
                Create_ETurrets(Build.rcDst.X + 180, Build.rcDst.Y + 35);
                Create_ETurrets(Build.rcDst.X + 80, Build.rcDst.Y + 290);
                Create_EDrone(Build.rcDst.X + 450, Build.rcDst.Y + 400, 0, 1);

            }

            if (Build.BFrame == 5 || test == 5)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 310;

                        }
                    }

                }
                Create_ETurrets(Build.rcDst.X + 80, Build.rcDst.Y + 15);
                Create_ETurrets(Build.rcDst.X + 140, Build.rcDst.Y + 425);
                Create_EDrone(Build.rcDst.X + 450, Build.rcDst.Y + 200, 0, 2);
            }
            if (Build.BFrame == 6 || test == 6)
            {
                if (Isstand)
                {
                    Isstand = false;
                    for (int i = 0; i < LHeros.Count; i++)
                    {
                        for (int j = 0; j < 8; j++)
                        {
                            LHeros[i].rcDst[j].X = 40;
                            LHeros[i].rcDst[j].Y = ClientSize.Height - 110;

                        }
                    }
                }
                Create_ETurrets(Build.rcDst.X + 80, Build.rcDst.Y + 20);
                Create_ETurrets(Build.rcDst.X + 470, Build.rcDst.Y + 550);
                Create_ETurrets(Build.rcDst.X + 70, Build.rcDst.Y + 220);
                Create_EDrone(Build.rcDst.X + 450, Build.rcDst.Y + 200, 0, 2);
                Create_EDrone(Build.rcDst.X + 120, Build.rcDst.Y + 650, 0, 2);
            }


            Build.rcSrc = new Rectangle(0, 0, Build.Building_img.Width, Build.Building_img.Height);

            LBuildings.Add(Build);
        }
        public void Create_ETurrets(int X_pos, int Y_pos)
        {
            ETurret Turret = new ETurret();
            for (int i = 0; i < 5; i++)
            {
                Turret.ETurret_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//turret//turret-" + (i + 1) + ".png");
            }
            Turret.rcDst[0] = new Rectangle(X_pos, Y_pos, Turret.ETurret_img[0].Width + 50, Turret.ETurret_img[0].Height + 50);
            Turret.rcSrc[0] = new Rectangle(0, 0, Turret.ETurret_img[0].Width, Turret.ETurret_img[0].Height);

            LETurrets.Add(Turret);
        }

        public void Animate_Turrets(int S)
        {

            for (int i = 0; i < LETurrets.Count; i++)
            {
                if (LETurrets[i].EturretFrame < 4)
                {
                    LETurrets[i].EturretFrame++;
                }
                else
                {
                    LETurrets[i].EturretFrame = 0;
                }
            }
            /*CreateEnemyWeaponShot(S);*/
        }
        public void Create_EDrone(int X_pos, int Y_pos, int Status, int Dir)
        {
            EDrone Drone = new EDrone();

            Drone.R_EDrone_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//drone//Right//drone-1.png");
            Drone.rcDst[0] = new Rectangle(X_pos, Y_pos, Drone.R_EDrone_img.Width + 20, Drone.R_EDrone_img.Height + 20);
            Drone.rcSrc[0] = new Rectangle(0, 0, Drone.R_EDrone_img.Width, Drone.R_EDrone_img.Height);


            Drone.L_EDrone_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//drone//Left//drone-1.png");
            Drone.rcDst[1] = new Rectangle(X_pos, Y_pos, Drone.L_EDrone_img.Width + 20, Drone.L_EDrone_img.Height + 20);
            Drone.rcSrc[1] = new Rectangle(0, 0, Drone.L_EDrone_img.Width, Drone.L_EDrone_img.Height);


            for (int i = 0; i < 6; i++)
            {
                Drone.EDroneExp_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//enemy-explosion//enemy-explosion-" + (i + 1) + ".png");
            }
            Drone.rcDst[2] = new Rectangle(X_pos, Y_pos, Drone.EDroneExp_img[0].Width + 20, Drone.EDroneExp_img[0].Height + 20);
            Drone.rcSrc[2] = new Rectangle(0, 0, Drone.EDroneExp_img[0].Width, Drone.EDroneExp_img[0].Height);

            for (int i = 0; i < LEDrones.Count; i++)
            {
                LEDrones[i].EDrone_Status = Status;
                LEDrones[i].EDrone_Status_Dir = Dir;
            }

            LEDrones.Add(Drone);
        }
        public void Animate_EDrone()
        {
            for (int i = 0; i < LEDrones.Count; i++)
            {
                if (LEDrones[0].EDrone_Status == 0)
                {
                    if (LEDrones[0].EDrone_Status_Dir == 1)
                    {
                        if (CtRight > 0)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                LEDrones[0].rcDst[j].X += 5;
                            }
                            CtRight--;
                        }
                        else
                        {
                            CtLeft = 5;

                            LEDrones[0].EDrone_Status_Dir = 2;
                        }

                    }
                    if (LEDrones[0].EDrone_Status_Dir == 2)
                    {
                        /* MessageBox.Show("Mina Eltayeb" + LEDrones[i].EDrone_Status_Dir);*/
                        if (CtLeft > 0)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                LEDrones[0].rcDst[j].X -= 5;
                            }
                            CtLeft--;
                            /* this.Text = CtLeft + "";*/
                        }
                        else
                        {
                            CtRight = 5;
                            LEDrones[0].EDrone_Status_Dir = 1;
                        }
                    }
                }
            }
        }
        public void Initiate_Buildings(int BFrame)
        {
            if (BFrame == 1)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    /*int xs = Border[i].x;
                    int xe = Border[i].x + Border[i].w;
                    int ys = Border[i].y;
                    int ye = Border[i].y + Border[i].h;

                    if (XM >= xs && XM <= xe && YM >= ys && YM <= ye ||
                        XU >= xs && XU <= xe && YM >= ys && YM <= ye ||
                        XM >= xs && XM <= xe && YU >= ys && YU <= ye ||
                        XU >= xs && XU <= xe && YU >= ys && YU <= ye)
                    {
                        Ball[0].x = OldPlacex;
                        Ball[0].y = OldPlacey;
                    }*/

                }
            }
        }
        public void Automate_Building_Creation()
        {
            if (GameStartStatus)
            {
                CreateMap_Buildings();
            }

            if (GameStartStatus && RunStatus)
            {
                /*for(int i=0; i<LHeros.Count; i++)
                {
                    if(LHeros[i].rcDst[i].X>0)
                    {
                        CreateMap_Obstacles();
                        LBuildings[i].rcDst[0].X += LHeros[i].rcDst[i].X;
                    }
                }*/
            }
        }

        public void SwitchHeroStatus(int NewState, int OldState)
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                LHeros[i].rcDst[NewState].X = LHeros[i].rcDst[OldState].X;
                LHeros[i].rcDst[NewState].Y = LHeros[i].rcDst[OldState].Y;
            }
        }

        public void Create_Hero_States()
        {
            Hero Hero = new Hero();

            //Idle State Right
            for (int i = 0; i < 3; i++)
            {
                Hero.R_IdleHero_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//idle//Right//idle-" + (i + 1) + ".png");
            }
            Hero.rcDst[0] = new Rectangle(ClientSize.Width / 4 - 350, ClientSize.Height / 4 + 455, Hero.R_IdleHero_img[0].Width + 20, Hero.R_IdleHero_img[0].Height + 20);
            Hero.rcSrc[0] = new Rectangle(0, 0, Hero.R_IdleHero_img[0].Width, Hero.R_IdleHero_img[0].Height);

            //Idle State Left
            for (int i = 0; i < 3; i++)
            {
                Hero.L_IdleHero_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//idle//Left//idle-" + (i + 1) + ".png");
            }
            Hero.rcDst[0] = new Rectangle(ClientSize.Width / 4 - 350, ClientSize.Height / 4 + 455, Hero.L_IdleHero_img[0].Width + 20, Hero.L_IdleHero_img[0].Height + 20);
            Hero.rcSrc[0] = new Rectangle(0, 0, Hero.L_IdleHero_img[0].Width, Hero.L_IdleHero_img[0].Height);

            //Run State Right
            for (int i = 0; i < 7; i++)
            {
                Hero.R_HeroRun_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//run//Right//rrun-" + (i + 1) + ".png");
            }
            Hero.rcDst[1] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroRun_img[0].Width + 20, Hero.R_HeroRun_img[0].Height + 20);
            Hero.rcSrc[1] = new Rectangle(0, 0, Hero.R_HeroRun_img[0].Width, Hero.R_HeroRun_img[0].Height);

            //Run State Left
            for (int i = 0; i < 7; i++)
            {
                Hero.L_HeroRun_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//run//Left//run-" + (i + 1) + ".png");
            }
            Hero.rcDst[1] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroRun_img[0].Width + 20, Hero.L_HeroRun_img[0].Height + 20);
            Hero.rcSrc[1] = new Rectangle(0, 0, Hero.L_HeroRun_img[0].Width, Hero.L_HeroRun_img[0].Height);

            //HeroJump State Right
            for (int i = 0; i < 3; i++)
            {
                Hero.R_HeroJump_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//jump//Right//jump-" + (i + 1) + ".png");
            }
            Hero.rcDst[2] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroJump_img[0].Width + 20, Hero.R_HeroJump_img[0].Height + 20);
            Hero.rcSrc[2] = new Rectangle(0, 0, Hero.R_HeroJump_img[0].Width, Hero.R_HeroJump_img[0].Height);

            //HeroJump State Left
            for (int i = 0; i < 3; i++)
            {
                Hero.L_HeroJump_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//jump//Left//jump-" + (i + 1) + ".png");
            }
            Hero.rcDst[2] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroJump_img[0].Width + 20, Hero.L_HeroJump_img[0].Height + 20);
            Hero.rcSrc[2] = new Rectangle(0, 0, Hero.L_HeroJump_img[0].Width, Hero.L_HeroJump_img[0].Height);

            //Shoot state Right
            Hero.R_HeroShoot_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//shoot//Right//shoot.png");
            Hero.rcDst[3] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroShoot_img.Width + 20, Hero.R_HeroShoot_img.Height + 20);
            Hero.rcSrc[3] = new Rectangle(0, 0, Hero.R_HeroShoot_img.Width, Hero.R_HeroShoot_img.Height);

            //Shoot state Left
            Hero.L_HeroShoot_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//shoot//Left//shoot.png");
            Hero.rcDst[3] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroShoot_img.Width + 20, Hero.L_HeroShoot_img.Height + 20);
            Hero.rcSrc[3] = new Rectangle(0, 0, Hero.L_HeroShoot_img.Width, Hero.L_HeroShoot_img.Height);

            //RunShoot State Right
            for (int i = 0; i < 7; i++)
            {
                Hero.R_HeroRunShoot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//run-shoot//Right//run-shoot-" + (i + 1) + ".png");
            }
            Hero.rcDst[4] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroRunShoot_img[0].Width + 20, Hero.R_HeroRunShoot_img[0].Height + 20);
            Hero.rcSrc[4] = new Rectangle(0, 0, Hero.R_HeroRunShoot_img[0].Width, Hero.R_HeroRunShoot_img[0].Height);

            //RunShoot State Left
            for (int i = 0; i < 7; i++)
            {
                Hero.L_HeroRunShoot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//run-shoot//Left//run-shoot-" + (i + 1) + ".png");
            }
            Hero.rcDst[4] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroRunShoot_img[0].Width + 20, Hero.L_HeroRunShoot_img[0].Height + 20);
            Hero.rcSrc[4] = new Rectangle(0, 0, Hero.L_HeroRunShoot_img[0].Width, Hero.L_HeroRunShoot_img[0].Height);

            //Crouch state Right
            Hero.R_HeroCrouch_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//Crouch//Right//Crouch.png");
            Hero.rcDst[5] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroCrouch_img.Width + 20, Hero.R_HeroCrouch_img.Height + 20);
            Hero.rcSrc[5] = new Rectangle(0, 0, Hero.R_HeroCrouch_img.Width, Hero.R_HeroCrouch_img.Height);

            //Crouch state Left
            Hero.L_HeroCrouch_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//Crouch//Left//Crouch.png");
            Hero.rcDst[5] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroCrouch_img.Width + 20, Hero.L_HeroCrouch_img.Height + 20);
            Hero.rcSrc[5] = new Rectangle(0, 0, Hero.L_HeroCrouch_img.Width, Hero.L_HeroCrouch_img.Height);

            //Hurt state Right
            Hero.R_HeroHurt_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//hurt//Right//hurt.png");
            Hero.rcDst[6] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.R_HeroHurt_img.Width + 40, Hero.R_HeroHurt_img.Height + 40);
            Hero.rcSrc[6] = new Rectangle(0, 0, Hero.R_HeroHurt_img.Width, Hero.R_HeroHurt_img.Height);

            //Hurt state Left
            Hero.L_HeroHurt_img = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//hurt//Left//hurt.png");
            Hero.rcDst[6] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.L_HeroHurt_img.Width + 20, Hero.L_HeroHurt_img.Height + 20);
            Hero.rcSrc[6] = new Rectangle(0, 0, Hero.L_HeroHurt_img.Width, Hero.L_HeroHurt_img.Height);

            //Climb State [No Dir]
            for (int i = 0; i < 4; i++)
            {
                Hero.Hero_Climb[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Character//climb//climb-" + (i + 1) + ".png");
            }
            Hero.rcDst[7] = new Rectangle(Hero.rcDst[0].X, Hero.rcDst[0].Y, Hero.Hero_Climb[0].Width + 20, Hero.Hero_Climb[0].Height + 20);
            Hero.rcSrc[7] = new Rectangle(0, 0, Hero.Hero_Climb[0].Width, Hero.Hero_Climb[0].Height);

            LHeros.Add(Hero);
        }

        public void Animate_IdleHero_Right()
        {

            if (IdleStatus)
            {
                if (LHeros[0].R_IdleFrames < 2)
                {
                    LHeros[0].R_IdleFrames++;
                }
                else
                {
                    LHeros[0].R_IdleFrames = 0;
                }
            }

        }
        public void Animate_IdleHero_Left()
        {
            if (IdleStatus)
            {
                if (LHeros[0].L_IdleFrames < 2)
                {
                    LHeros[0].L_IdleFrames++;
                }
                else
                {
                    LHeros[0].L_IdleFrames = 0;
                }
            }
        }

        public void Animate_RunningHero_Right()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].R_RunFrames < 5)
                {
                    LHeros[i].R_RunFrames++;
                }
                else
                {
                    LHeros[i].R_RunFrames = 0;
                }
            }
        }
        public void Animate_RunningHero_Left()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].L_RunFrames < 5)
                {
                    LHeros[i].L_RunFrames++;
                }
                else
                {
                    LHeros[i].L_RunFrames = 0;
                }
            }
        }
        public void Animate_CrouchHero_Right()
        {


        }
        public void Animate_CrouchHero_Left()
        {


        }

        public void Animate_JumpingHero_Right()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].R_JumpFrames < 2)
                {
                    LHeros[i].R_JumpFrames++;
                }
                else
                {
                    LHeros[i].R_JumpFrames = 0;
                }
            }
        }
        public void Animate_JumpingHero_Left()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].L_JumpFrames < 2)
                {
                    LHeros[i].L_JumpFrames++;
                }
                else
                {
                    LHeros[i].L_JumpFrames = 0;
                }
            }
        }
        public void Animate_ClimbingHero()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].HeroClimb_Frames < 2)
                {
                    LHeros[i].HeroClimb_Frames++;
                }
                else
                {
                    LHeros[i].HeroClimb_Frames = 0;
                }
            }
        }

        public void Animate_RunShootHero_Right()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].R_RunShootFrames < 5)
                {
                    LHeros[i].R_RunShootFrames++;
                }
                else
                {
                    LHeros[i].R_RunShootFrames = 0;
                }
            }
        }

        public void Animate_ShootHero_Right()
        {


        }
        public void Animate_ShootHero_Left()
        {


        }

        public void Animate_RunShootHero_Left()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros[i].L_RunShootFrames < 5)
                {
                    LHeros[i].L_RunShootFrames++;
                }
                else
                {
                    LHeros[i].L_RunShootFrames = 0;
                }
            }
        }
        public void CreateEnemyWeaponShot()
        {

            ETurretShot EnemyShot = new ETurretShot();
            //HeroShoot State Right

            for (int i = 0; i < 2; i++)
            {
                EnemyShot.R_WeaponShot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//shot//Right//shot-" + (i + 1) + ".png");
            }
            /* Bullet.rcDst[0] = new Rectangle(50, 50, Bullet.R_WeaponShot_img[0].Width + 30, Bullet.R_WeaponShot_img[0].Height + 30);*/
            for (int i = 0; i < LETurrets.Count; i++)
            {
                EnemyShot.rcDst[0] = new Rectangle(LETurrets[i].rcDst[0].X + 30, LETurrets[i].rcDst[0].Y + 25, EnemyShot.R_WeaponShot_img[0].Width + 3, EnemyShot.R_WeaponShot_img[0].Height + 3);
            }
            EnemyShot.rcSrc[0] = new Rectangle(0, 0, EnemyShot.R_WeaponShot_img[0].Width, EnemyShot.R_WeaponShot_img[0].Height);


            //HeroShoot State Left
            for (int i = 0; i < 2; i++)
            {
                EnemyShot.L_WeaponShot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//shot//Left//shot-" + (i + 1) + ".png");
            }
            for (int i = 0; i < LETurrets.Count; i++)
            {
                EnemyShot.rcDst[1] = new Rectangle(LETurrets[i].rcDst[0].X + 30, LETurrets[i].rcDst[0].Y + 25, EnemyShot.L_WeaponShot_img[0].Width + 3, EnemyShot.L_WeaponShot_img[0].Height + 3);
            }
            EnemyShot.rcSrc[1] = new Rectangle(0, 0, EnemyShot.L_WeaponShot_img[0].Width, EnemyShot.L_WeaponShot_img[0].Height);

           
            LETurretsShots.Add(EnemyShot);



            /*SFX mpnn = new SFX();
            mpnn.Track[1] = new SoundPlayer(@"C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Sounds//beam.wav");
            mpnn.Track[1].Play();
            ShootSFX = true;*/

            if (spray == 1)
            {

                Animate_EnemyWeaponShot_Left();
            }

            if (spray == 1)
            {

                Animate_EnemyWeaponShot_Right();
            }

        }
        public void Animate_EnemyWeaponShot_Right()
        {
            for (int i = 0; i < LETurretsShots.Count; i++)
            {
                LETurretsShots[i].rcDst[0].X += 10;

                if (LETurretsShots[i].R_ShotFrames < 1)
                {
                    LETurretsShots[i].R_ShotFrames++;
                }
                else
                {
                    LETurretsShots[i].R_ShotFrames = 0;
                }
            }
        }
        public void Animate_EnemyWeaponShot_Left()
        {
            for (int i = 0; i < LETurretsShots.Count; i++)
            {
                LETurretsShots[i].rcDst[1].X -= 10;

                if (LETurretsShots[i].L_ShotFrames < 1)
                {
                    LETurretsShots[i].L_ShotFrames++;
                }
                else
                {
                    LETurretsShots[i].L_ShotFrames = 0;
                }
            }
        }
        public void CreateWeaponShot()
        {
            WeaponShot Bullet = new WeaponShot();
            //HeroShoot State Right
            if (ShootWeaponRight)
            {
                for (int i = 0; i < 2; i++)
                {
                    Bullet.R_WeaponShot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//shot//Right//shot-" + (i + 1) + ".png");
                }
                /* Bullet.rcDst[0] = new Rectangle(50, 50, Bullet.R_WeaponShot_img[0].Width + 30, Bullet.R_WeaponShot_img[0].Height + 30);*/
                for (int i = 0; i < LHeros.Count; i++)
                {
                    Bullet.rcDst[0] = new Rectangle(LHeros[i].rcDst[0].X + 30, LHeros[i].rcDst[0].Y + 25, Bullet.R_WeaponShot_img[0].Width + 3, Bullet.R_WeaponShot_img[0].Height + 3);
                }
                Bullet.rcSrc[0] = new Rectangle(0, 0, Bullet.R_WeaponShot_img[0].Width, Bullet.R_WeaponShot_img[0].Height);
            }

            if (ShootWeaponLeft)
            {
                //HeroShoot State Right
                for (int i = 0; i < 2; i++)
                {
                    Bullet.L_WeaponShot_img[i] = new Bitmap("C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Enemy_Actions//shot//Left//shot-" + (i + 1) + ".png");
                }
                for (int i = 0; i < LHeros.Count; i++)
                {
                    Bullet.rcDst[1] = new Rectangle(LHeros[i].rcDst[0].X + 30, LHeros[i].rcDst[0].Y + 25, Bullet.L_WeaponShot_img[0].Width + 3, Bullet.L_WeaponShot_img[0].Height + 3);
                }
                Bullet.rcSrc[1] = new Rectangle(0, 0, Bullet.L_WeaponShot_img[0].Width, Bullet.L_WeaponShot_img[0].Height);
            }
            LShots.Add(Bullet);

            SFX mpnn = new SFX();
            mpnn.Track[1] = new SoundPlayer(@"C://Users//youss//Desktop//UNIVERSITY SHIT//YEAR 2//SEMESTER 2//CS232 - Multi-Media Programming//Projects//BigGame - WarpedCity//Assets//Sounds//beam.wav");
            mpnn.Track[1].Play();
            ShootSFX = true;

        }
        public void Animate_WeaponShot_Right()
        {
            for (int i = 0; i < LShots.Count; i++)
            {
                LShots[i].rcDst[0].X += 10;

                if (LShots[i].R_ShotFrames < 1)
                {
                    LShots[i].R_ShotFrames++;
                }
                else
                {
                    LShots[i].R_ShotFrames = 0;
                }
            }
        }
        public void Animate_WeaponShot_Left()
        {
            for (int i = 0; i < LShots.Count; i++)
            {
                LShots[i].rcDst[1].X -= 10;

                if (LShots[i].L_ShotFrames < 1)
                {
                    LShots[i].L_ShotFrames++;
                }
                else
                {
                    LShots[i].L_ShotFrames = 0;
                }
            }
        }
        public int Hit_EnemyTurret()
        {
            for (int i = 0; i < LShots.Count; i++)
            {
                int SXS = LShots[i].rcDst[0].X;
                int SXE = LShots[i].rcDst[0].X + LShots[i].rcDst[0].Width;
                int SYS = LShots[i].rcDst[0].Y;
                
                int SYE = LShots[i].rcDst[0].Y + LShots[i].rcDst[0].Height;

                for (int j = 0; j < LETurrets.Count; j++)
                {
                    int TXS = LETurrets[j].rcDst[0].X;
                    int TXE = LETurrets[j].rcDst[0].X + LETurrets[j].rcDst[0].Width;
                    int TYS = LETurrets[j].rcDst[0].Y;
                    int TYE = LETurrets[j].rcDst[0].Y + LETurrets[j].rcDst[0].Height + 20;
                    if (SXS >= TXS && SXE <= TXE && SYS >= TYS && SYE <= TYE)
                    {
                        LShots.Remove(LShots[i]);
                        return j;
                    }
                }

            }
            return -1;
        }
        public int Hit_HeroTurret()
        {
            for (int i = 0; i < LShots.Count; i++)
            {
                int SXS = LShots[i].rcDst[0].X;
                int SXE = LShots[i].rcDst[0].X + LShots[i].rcDst[0].Width;
                int SYS = LShots[i].rcDst[0].Y;
                int SYE = LShots[i].rcDst[0].Y + LShots[i].rcDst[0].Height;

                for (int j = 0; j < LETurrets.Count; j++)
                {
                    int TXS = LETurrets[j].rcDst[0].X;
                    int TXE = LETurrets[j].rcDst[0].X + LETurrets[j].rcDst[0].Width;
                    int TYS = LETurrets[j].rcDst[0].Y;
                    int TYE = LETurrets[j].rcDst[0].Y + LETurrets[j].rcDst[0].Height + 20;

                    if (SXS >= TXS && SXE <= TXE && SYS >= TYS && SYE <= TYE)
                    {
                        LShots.Remove(LShots[i]);
                        return j;
                    }
                }

            }
            return -1;
        }

        public int Hit_Bounds() //Not Working
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                int HXS = LHeros[i].rcDst[0].X;
                int HXE = LHeros[i].rcDst[0].X + LHeros[i].rcDst[0].Width;
                int HYS = LHeros[i].rcDst[0].Y;
                int HYE = LHeros[i].rcDst[0].Y + LHeros[i].rcDst[0].Height;

                for (int j = 0; j < LBuildings.Count; j++)
                {
                    int BXS = LBuildings[j].rcDst.X;
                    int BXE = LBuildings[j].rcDst.X + LBuildings[j].rcDst.Width;


                    if (HXS >= BXS && HXE <= BXE)
                    {
                        for (int k = 0; k < LHeros.Count; k++)
                        {
                            LHeros[i].rcDst[j].Y -= 4;

                        }
                        return j;
                    }
                }

            }
            return -1;
        }
        public int Hit_EnemyDrone()
        {
            for (int i = 0; i < LShots.Count; i++)
            {
                int SXS = LShots[i].rcDst[0].X;
                int SXE = LShots[i].rcDst[0].X + LShots[i].rcDst[0].Width;
                int SYS = LShots[i].rcDst[0].Y;
                int SYE = LShots[i].rcDst[0].Y + LShots[i].rcDst[0].Height;

                for (int j = 0; j < LEDrones.Count; j++)
                {
                    int DXS = LEDrones[j].rcDst[0].X;
                    int DXE = LEDrones[j].rcDst[0].X + LEDrones[j].rcDst[0].Width;
                    int DYS = LEDrones[j].rcDst[0].Y;
                    int DYE = LEDrones[j].rcDst[0].Y + LEDrones[j].rcDst[0].Height;

                    if (SXS >= DXS && SXE <= DXE && SYS >= DYS && SYE <= DYE)
                    {
                        LShots.Remove(LShots[i]);
                        return j;
                    }
                }

            }
            return -1;
        }

        public void MoveCamX()
        {
            for (int i = 0; i < LHeros.Count; i++)
            {
                if (LHeros.Count > 0 && LHeros[0].Hero_Status == 1 || LHeros[0].Hero_Status == 2)
                {
                    for (int j = 0; j < LBuildings.Count; j++)
                    {

                        LBuildings[j].rcDst.X += CamX;


                    }
                    for (int k = 0; k < LETurrets.Count; k++)
                    {
                        LETurrets[k].rcDst[0].X += CamX;
                    }
                    for (int k = 0; k < LEDrones.Count; k++)
                    {
                        LEDrones[k].rcDst[0].X += CamX;
                        LEDrones[k].rcDst[1].X += CamX;

                    }
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:

                    if (!GameStartStatus)
                    {
                        RemoveStartScreen();
                        LaunchGame();
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            SwitchHeroStatus(LHeros[i].Hero_Status, 1);
                            LHeros[i].Hero_Status_Dir = 1;
                        }

                        GameStartStatus = true;
                        LiftW = false;
                    }
                    break;

                case Keys.D:

                    if (GameStartStatus)
                    {

                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].Hero_Status = 1;
                            LHeros[i].Hero_Status_Dir = 1;
                        }

                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            Animate_RunningHero_Right();
                            LHeros[i].rcDst[1].X += 8;
                            LHeros[i].R_RunFrames++;

                            /*AnimateMap_Obstacles();*/
                        }
                        CamX = -10;
                        CamXFlag = 1;
                        LiftD = true;
                        LiftW = false;

                    }

                    break;

                case Keys.A:

                    if (GameStartStatus)
                    {
                        for (int j = 0; j < LHeros.Count; j++)
                        {
                            if (LHeros[j].rcDst[1].X >= 10)
                            {
                                for (int i = 0; i < LHeros.Count; i++)
                                {
                                    LHeros[i].Hero_Status = 1;
                                    LHeros[i].Hero_Status_Dir = 2;
                                }

                                for (int i = 0; i < LHeros.Count; i++)
                                {
                                    Animate_RunningHero_Left();
                                    LHeros[i].rcDst[1].X -= 8;
                                    LHeros[i].L_RunFrames++;
                                    /* AnimateMap_Obstacles();*/
                                }
                                LiftA = true;
                            }
                        }
                        CamX = 10;
                        CamXFlag = 2;
                    }

                    break;

                case Keys.S:

                    if (GameStartStatus)
                    {
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].Hero_Status = 5;
                            LHeros[i].rcDst[5].X = LHeros[i].rcDst[0].X;

                        }
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].Hero_Status = 5;
                            LHeros[i].rcDst[5].X = LHeros[i].rcDst[0].X;

                        }


                        LiftS = true;
                    }

                    break;
                case Keys.Z:

                    if (GameStartStatus)
                    {
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            for (int j = 0; j < LHeros.Count; j++)
                            {
                                LHeros[i].Hero_Status = 0;
                                LHeros[i].rcDst[j].Y += 40;


                            }

                        }


                    }

                    break;

                case Keys.W:

                    if (GameStartStatus)
                    {

                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].Hero_Status = 7;
                            LHeros[i].Hero_Status_Dir = 0;
                        }

                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            Animate_ClimbingHero();
                            LHeros[i].HeroClimb_Frames++;
                            for (int k = 0; k < 8; k++)
                            {
                                LHeros[i].rcDst[k].Y -= 8;

                            }


                        }
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].rcDst[7].X = LHeros[i].rcDst[1].X;
                        }
                        LiftW = true;
                        DoneClimb = false;
                        /* AnimateMap_Obstacles();*/
                    }
                    /* LHeros[i].rcDst[0].Y = LHeros[i].rcDst[7].Y;*/

                    break;


                case Keys.E:

                    if (GameStartStatus)
                    {
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            LHeros[i].Hero_Status = 3;
                            LHeros[i].rcDst[3].X = LHeros[i].rcDst[0].X;
                        }
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            if (LHeros[i].Hero_Status == 3 && LHeros[i].Hero_Status_Dir == 1)
                            {

                                ShootWeaponRight = true;
                                CreateWeaponShot();
                                LShots[LShots.Count - 1].Hero_Status_Dir = LHeros[i].Hero_Status_Dir;


                            }
                            if (LHeros[i].Hero_Status == 3 && LHeros[i].Hero_Status_Dir == 2)
                            {

                                ShootWeaponLeft = true;
                                CreateWeaponShot();
                                LShots[LShots.Count - 1].Hero_Status_Dir = LHeros[i].Hero_Status_Dir;

                            }
                        }


                        LiftE = true;
                    }

                    break;


                case Keys.Space:

                    if (GameStartStatus && CtJump == 0)
                    {
                        for (int i = 0; i < LHeros.Count; i++)
                        {

                            LHeros[i].rcDst[2].X = LHeros[i].rcDst[0].X;
                        }
                        for (int i = 0; i < LHeros.Count; i++)
                        {
                            OldY = LHeros[0].rcDst[0].Y;
                            for (int j = 0; j < LHeros.Count; j++)
                            {
                                IsJump = true;
                                LHeros[i].rcDst[2].Y -= 8;
                                LHeros[i].Hero_Status = 2;
                            }

                        }

                        CtJump = 5;
                        LiftSpace = true;
                    }

                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (LiftS && LiftA)
            {

            }
            if (LiftD)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    SwitchHeroStatus(0, 1);
                    LHeros[i].Hero_Status = 0;
                    LHeros[i].Hero_Status_Dir = 1;
                }
                LiftD = false;

            }

            if (LiftA)
            {

                for (int i = 0; i < LHeros.Count; i++)
                {
                    SwitchHeroStatus(0, 1);
                    LHeros[i].Hero_Status = 0;
                    LHeros[i].Hero_Status_Dir = 2;
                }
                LiftA = false;

            }

            if (LiftS)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    if (LHeros[i].Hero_Status_Dir == 1)
                    {
                        SwitchHeroStatus(5, 1);
                        LHeros[i].Hero_Status = 0;
                        LHeros[i].Hero_Status_Dir = 1;
                    }

                    if (LHeros[i].Hero_Status_Dir == 2)
                    {
                        SwitchHeroStatus(5, 1);
                        LHeros[i].Hero_Status = 0;
                        LHeros[i].Hero_Status_Dir = 2;
                    }
                }

                LiftA = false;
                LiftD = false;
                LiftS = false;
            }
            if (LiftW == true)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    if (LHeros[i].Hero_Status_Dir == 1 || LHeros[i].Hero_Status_Dir == 2)
                    {
                        SwitchHeroStatus(7, 1);
                        LHeros[i].Hero_Status = 0;
                        LHeros[i].Hero_Status_Dir = 1;
                    }
                }
                /*LiftA = false;
                LiftD = false;*/
                LiftW = false;
                DoneClimb = true;
            }

            if (LiftSpace)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {

                    LHeros[i].Hero_Status = 2;
                    LHeros[i].rcDst[0].Y = OldY;

                }
                LiftSpace = false;
            }

            if (LiftE)
            {
                for (int i = 0; i < LHeros.Count; i++)
                {
                    if (LHeros[i].Hero_Status_Dir == 1)
                    {
                        SwitchHeroStatus(3, 1);
                        LHeros[i].Hero_Status = 0;
                        LHeros[i].Hero_Status_Dir = 1;
                    }

                    if (LHeros[i].Hero_Status_Dir == 2)
                    {
                        SwitchHeroStatus(3, 1);
                        LHeros[i].Hero_Status = 0;
                        LHeros[i].Hero_Status_Dir = 2;
                    }
                }
                ShootWeaponRight = false;
                ShootWeaponLeft = false;

                /* LiftA = false;
                 LiftD = false;
                 LiftS = false;*/
                LiftE = false;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        void DrawScene(Graphics g2)
        {
            g2.Clear(Color.Black);

            for (int i = 0; i < LStarts.Count; i++)
            {
                Rectangle rcDst = new Rectangle(LStarts[i].X_SBG, LStarts[i].Y_SBG, LStarts[i].SBG_Width, LStarts[i].SBG_Height);
                Rectangle rcSrc = new Rectangle(0, 0, LStarts[i].Start_Background_img.Width, LStarts[i].Start_Background_img.Height);
                g2.DrawImage(LStarts[i].Start_Background_img, rcDst, rcSrc, GraphicsUnit.Pixel);

                Rectangle rcDst1 = new Rectangle(LStarts[i].X_Title, LStarts[i].Y_Title, LStarts[i].Title_Width, LStarts[i].Title_Height);
                Rectangle rcSrc1 = new Rectangle(0, 0, LStarts[i].Title_img.Width, LStarts[i].Title_img.Height);
                g2.DrawImage(LStarts[i].Title_img, rcDst1, rcSrc1, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LBGs.Count; i++)
            {
                g2.DrawImage(LBGs[i].BackgroundMap_img, LBGs[i].rcDst, LBGs[i].rcSrc, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LEnters.Count; i++)
            {
                Rectangle rcDst1 = new Rectangle(LEnters[i].X_SB, LEnters[i].Y_SB, LEnters[i].SBTN_Width, LEnters[i].SBTN_Height);
                Rectangle rcSrc1 = new Rectangle(0, 0, LEnters[i].Start_Btn_img.Width, LEnters[i].Start_Btn_img.Height);
                g2.DrawImage(LEnters[i].Start_Btn_img, rcDst1, rcSrc1, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LVehicles.Count; i++)
            {
                g2.DrawImage(LVehicles[i].R_Vehicle_img, LVehicles[i].rcDst[0], LVehicles[i].rcSrc[0], GraphicsUnit.Pixel);
                g2.DrawImage(LVehicles[i].L_Vehicle_img, LVehicles[i].rcDst[1], LVehicles[i].rcSrc[1], GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LBuildings.Count; i++)
            {
                g2.DrawImage(LBuildings[i].Building_img, LBuildings[i].rcDst, LBuildings[i].rcSrc, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LETurrets.Count; i++)
            {
                g2.DrawImage(LETurrets[i].ETurret_img[LETurrets[i].EturretFrame], LETurrets[i].rcDst[0], LETurrets[i].rcSrc[0], GraphicsUnit.Pixel);
            }

            for (int i = 0; i < LETurretsShots.Count; i++)
            {
                if (LETurretsShots[i].Shot_Dir == 1)
                {
                    g2.DrawImage(LETurretsShots[i].R_WeaponShot_img[LShots[i].R_ShotFrames], LETurretsShots[i].rcDst[0], LETurretsShots[i].rcSrc[0], GraphicsUnit.Pixel);
                }
                else if (LETurretsShots[i].Shot_Dir == 2)
                {
                    g2.DrawImage(LETurretsShots[i].L_WeaponShot_img[LShots[i].L_ShotFrames], LETurretsShots[i].rcDst[1], LETurretsShots[i].rcSrc[1], GraphicsUnit.Pixel);
                }
            }

            for (int i = 0; i < LEDrones.Count; i++)
            {

                if (LEDrones[i].EDrone_Status == 0 && LEDrones[i].EDrone_Status_Dir == 1)
                {
                    g2.DrawImage(LEDrones[i].R_EDrone_img, LEDrones[i].rcDst[0], LEDrones[i].rcSrc[0], GraphicsUnit.Pixel);
                }
                else if (LEDrones[i].EDrone_Status == 0 && LEDrones[i].EDrone_Status_Dir == 2)
                {
                    g2.DrawImage(LEDrones[i].L_EDrone_img, LEDrones[i].rcDst[1], LEDrones[i].rcSrc[1], GraphicsUnit.Pixel);
                }
                else if (LEDrones[i].EDrone_Status == 1 && LEDrones[i].EDrone_Status_Dir == 1 || LEDrones[i].EDrone_Status_Dir == 2)
                {
                    g2.DrawImage(LEDrones[i].EDroneExp_img[LEDrones[i].EDroneExpFrame], LEDrones[i].rcDst[2], LEDrones[i].rcSrc[2], GraphicsUnit.Pixel);
                }
            }

            for (int i = 0; i < LETurretsShots.Count; i++)
            {
                if (spray == 1)
                {
                    g2.DrawImage(LETurretsShots[i].R_WeaponShot_img[LShots[i].R_ShotFrames], LETurretsShots[i].rcDst[0], LShots[i].rcSrc[0], GraphicsUnit.Pixel);
                }
                else if (spray == 2)
                {
                    g2.DrawImage(LETurretsShots[i].L_WeaponShot_img[LShots[i].L_ShotFrames], LETurretsShots[i].rcDst[1], LETurretsShots[i].rcSrc[1], GraphicsUnit.Pixel);
                }
            }

            for (int i = 0; i < LShots.Count; i++)
            {
                if (LShots[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LShots[i].R_WeaponShot_img[LShots[i].R_ShotFrames], LShots[i].rcDst[0], LShots[i].rcSrc[0], GraphicsUnit.Pixel);
                }
                else if (LShots[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LShots[i].L_WeaponShot_img[LShots[i].L_ShotFrames], LShots[i].rcDst[1], LShots[i].rcSrc[1], GraphicsUnit.Pixel);
                }
            }

            for (int i = 0; i < LHeros.Count; i++)
            {
                //IDle
                if (LHeros[i].Hero_Status == 0 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_IdleHero_img[LHeros[i].R_IdleFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 0 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_IdleHero_img[LHeros[i].L_IdleFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Run
                if (LHeros[i].Hero_Status == 1 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroRun_img[LHeros[i].R_RunFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 1 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroRun_img[LHeros[i].L_RunFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Jump
                if (LHeros[i].Hero_Status == 2 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroJump_img[LHeros[i].R_JumpFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 2 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroJump_img[LHeros[i].L_JumpFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Shoot
                if (LHeros[i].Hero_Status == 3 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroShoot_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 3 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroShoot_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //RunShoot
                if (LHeros[i].Hero_Status == 4 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroRunShoot_img[LHeros[i].R_RunShootFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 4 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroRunShoot_img[LHeros[i].L_RunShootFrames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Crouch
                if (LHeros[i].Hero_Status == 5 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroCrouch_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 5 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroCrouch_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Hurt
                if (LHeros[i].Hero_Status == 6 && LHeros[i].Hero_Status_Dir == 1)
                {
                    g2.DrawImage(LHeros[i].R_HeroHurt_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
                else if (LHeros[i].Hero_Status == 6 && LHeros[i].Hero_Status_Dir == 2)
                {
                    g2.DrawImage(LHeros[i].L_HeroHurt_img, LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }

                //Climb
                if (LHeros[i].Hero_Status == 7 && LHeros[i].Hero_Status_Dir == 0)
                {
                    g2.DrawImage(LHeros[i].Hero_Climb[LHeros[i].HeroClimb_Frames], LHeros[i].rcDst[LHeros[i].Hero_Status], LHeros[i].rcSrc[LHeros[i].Hero_Status], GraphicsUnit.Pixel);
                }
            }
        }

        void DrawDubb()
        {
            Graphics g = CreateGraphics();
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }

    }
}
