using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace DataAccessLayer
{
 public   class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand command1 = new SqlCommand("select * from TBLBILGI", Baglanti.bgl);
            if (command1.Connection.State != ConnectionState.Open)
            {
                command1.Connection.Open();
            }
            SqlDataReader DR = command1.ExecuteReader();
            while (DR.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(DR["ID"].ToString());
                ent.Ad = DR["AD"].ToString();
                ent.Soyad = DR["SOYAD"].ToString();
                ent.Gorev = DR["GOREV"].ToString();
                ent.Sehir = DR["SEHIR"].ToString();
                ent.Maas = short.Parse(DR["MAAS"].ToString());
                degerler.Add(ent);
            }
            DR.Close();
            return degerler;

        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand command2 = new SqlCommand("insert into TBLBILGI(AD,SOYAD,GOREV,SEHIR,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (command2.Connection.State != ConnectionState.Open)
            {
                command2.Connection.Open();
            }
            command2.Parameters.AddWithValue("@P1", p.Ad);
            command2.Parameters.AddWithValue("@P2", p.Soyad);
            command2.Parameters.AddWithValue("@P3", p.Gorev);
            command2.Parameters.AddWithValue("@P4", p.Sehir);
            command2.Parameters.AddWithValue("@P5", p.Maas);
            return command2.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand commad3 = new SqlCommand("delete from TBLBILGI where ID=@P1", Baglanti.bgl);
            if (commad3.Connection.State != ConnectionState.Open)
            {
                commad3.Connection.Open();
            }
            commad3.Parameters.AddWithValue("@P1", p);
            return commad3.ExecuteNonQuery() > 0;
        }
        public static bool PersonelGuncelle(EntityPersonel ent)
        {
            SqlCommand command4 = new SqlCommand("update TBLBILGI SET AD=@P1,SOYAD=P2, MAAS=@P3,SEHIR=@P4,GOREV=@P5 WHERE ID=@P6", Baglanti.bgl);
            if (command4.Connection.State != ConnectionState.Open)
            {
                command4.Connection.Open();
            }
            command4.Parameters.AddWithValue("@P1", ent.Ad);
            command4.Parameters.AddWithValue("@P2", ent.Soyad);
            command4.Parameters.AddWithValue("@P3", ent.Maas);
            command4.Parameters.AddWithValue("@P4", ent.Sehir);
            command4.Parameters.AddWithValue("@P5", ent.Gorev);
            command4.Parameters.AddWithValue("@P6", ent.Id);
            return command4.ExecuteNonQuery() > 0;
        }
    }
}
