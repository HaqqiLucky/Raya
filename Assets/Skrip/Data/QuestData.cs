using System;
using System.Collections.Generic;
using UnityEngine;


public enum NPCidTranlate
{
    Anisa = 01000001,
    Ranto = 102,
    Indah = 103,
    Raka = 104,
    Jainah = 105,
    Nia = 106,
    Haqi =  01001000,
    Liam = 01001100,
    Sakinah = 01010011,
    Raya = 01010010,
    Reza = 00111111


}
[Serializable]
public class QuestVariable
{
    public int idQuestData;
    public NPCidTranlate idNPC;
    public string objektif;
    public string namaAct;

    // buat constructor
    public QuestVariable(int idQD, NPCidTranlate idNP, string obj, string act)
    {
        idQuestData = idQD;
        idNPC = idNP;
        objektif = obj;
        namaAct = act;

    }
}

public class QuestData
{
    public List<QuestVariable> daftarQuest = new List<QuestVariable>()
    {
        // act 1
        new QuestVariable(1, NPCidTranlate.Anisa, "Bicara pada nona berbaju hijau", "Act_1_2"),
        new QuestVariable(2, NPCidTranlate.Ranto, "Cari orang dengan nama pak ranto", "Act_1_3"),
        new QuestVariable(3, NPCidTranlate.Ranto, "Cari ketiga kucing di sekitar", "Act_1_4"), // butuh variabel int kucing yang di ambil 1/3
        new QuestVariable(4, NPCidTranlate.Indah, "Cari orang dengan nama Indah", "Act_1_5"),
        new QuestVariable(5, NPCidTranlate.Indah, "Ambil air dari sumur sebelah barat desa", "Act_1_6"), // butuh variabel int ember 1/5



        // act 2
        new QuestVariable(6, NPCidTranlate.Anisa, "Kembali ke anisa dan istirahat di pusat", "Act2_0"),
        new QuestVariable(7, NPCidTranlate.Raya, "Buka surat", "Act2_1"), //ini harusnya surat
        new QuestVariable(8, NPCidTranlate.Anisa, "Kembali ke anisa dan istirahat di pusat", "Act2_0"),


        // act3
        new QuestVariable(9, NPCidTranlate.Anisa, "Ambil tugas dari anisa", "Act3_0"),
        new QuestVariable(10, NPCidTranlate.Jainah, "Cari orang dengan nama Jainah", "Act3_1"),
        new QuestVariable(11, NPCidTranlate.Raka, "Cari orang dengan nama Raka", "Act3_2"),
        new QuestVariable(12, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_3"), // 1/4 jalan
        new QuestVariable(13, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_4"), // 2/4 jalan
        new QuestVariable(14, NPCidTranlate.Raka, "Ikuti Pak Raka", "Act3_5"), // 3/4 jalan

        // act4 
        new QuestVariable(15, NPCidTranlate.Raya, "....", "Act4_0"),
        new QuestVariable(16, NPCidTranlate.Anisa, "Balik ke pusat dan bicara kepada anisa", "Act4_1"),
        new QuestVariable(17, NPCidTranlate.Raya, "Baca surat", "Act4_2"),
        new QuestVariable(18, NPCidTranlate.Anisa, "Tanyakan perihal surat kepada anisa", "Act4_3"),

        // act 5
        new QuestVariable(19, NPCidTranlate.Raya, "Cari mood", "Act5_0"),
        new QuestVariable(20, NPCidTranlate.Anisa, "Bicara pada anisa", "Act5_1"),
        new QuestVariable(21, NPCidTranlate.Nia, "Cari orang dengan nama Nia", "Act5_2"),
        new QuestVariable(22, NPCidTranlate.Nia, "Selesaikan tugas mu dan bicara pada bu nia", "Act5_3"),
        new QuestVariable(23, NPCidTranlate.Raya, "Cari bocil di sekitar hutan", "Act5_4"),
        new QuestVariable(24, NPCidTranlate.Haqi, "Cari bocil di sekitar hutan", "Act5_5"),
        new QuestVariable(25, NPCidTranlate.Haqi, "Menangkan pertandingan", "Act5_6"),

        //act 6
        new QuestVariable(26, NPCidTranlate.Anisa, "Bicara dengan anisa", "Act6_0"),
        new QuestVariable(27, NPCidTranlate.Raya, "Cari bu jainah dan tanyakan tentang patung", "Act6_1"),
        new QuestVariable(28, NPCidTranlate.Raya, "Pergi ke depan patung dewi takdir", "Act6_2"),
        new QuestVariable(29, NPCidTranlate.Raya, "Cari persembahan untuk diberikan", "Act6_3"), // kasi petunjuk gmn nyari chest atau gambar aja

        // act 7
        new QuestVariable(30, NPCidTranlate.Anisa, "Bicara dengan anisa", "Act7_0"),
        new QuestVariable(31, NPCidTranlate.Liam, "Cari bocil di sekitar hutan", "Act7_1"),
        new QuestVariable(32, NPCidTranlate.Liam, "Cari Liam", "Act7_2"),
        new QuestVariable(33, NPCidTranlate.Liam, "Cari Liam lagi", "Act7_3"),
        new QuestVariable(34, NPCidTranlate.Raya, "Cari bocil di tengah hutan", "Act7_4"),
        new QuestVariable(35, NPCidTranlate.Raya, "Dekati bocil cewe", "Act7_5"),
        new QuestVariable(36, NPCidTranlate.Sakinah, "Ajak bicara si bocil", "Act7_6"),

        // act 8
        new QuestVariable(37, NPCidTranlate.Raya, "Kembali ke pusat dan kabari anisa", "Act8_0"),
        new QuestVariable(38, NPCidTranlate.Raya, "Investigasi area patung", "Act8_1_1Patung"),
        new QuestVariable(39, NPCidTranlate.Raya, "Investigasi area perumahan", "Act8_1_2Perumahan"),
        new QuestVariable(40, NPCidTranlate.Raya, "Jalan ke arah pusat", "Act8_2"),

        // act 9
        new QuestVariable(41, NPCidTranlate.Anisa, "Bicara dengan anisa", "Act9_0"),
        new QuestVariable(42, NPCidTranlate.Raka, "Bicara dengan pak raka", "Act9_1"),
        new QuestVariable(43, NPCidTranlate.Raka, "Selesaikan tugasmu dengan pak raka", "Act9_2"), // ambil ember 5

        // act 10
        new QuestVariable(44, NPCidTranlate.Raya, "Diskusikan dengan dirimu sendiri", "Act10_0"),
        new QuestVariable(45, NPCidTranlate.Raya, "Pergi ke patung dewi takdir", "Act10_1"),
        new QuestVariable(46, NPCidTranlate.Raya, "Cari semua peti yang tersisa dan berikan sebagai persembahan", "Act10_2"),
        new QuestVariable(47, NPCidTranlate.Raya, "Diskusikan dengan dirimu", "Act10_3"),
        new QuestVariable(48, NPCidTranlate.Anisa, "Pergi ke pusat dan beritahukan anisa", "Act10_4"),
        new QuestVariable(49, NPCidTranlate.Raya, "Introgasi patung", "Act10_5"),
        new QuestVariable(50, NPCidTranlate.Reza, "Bicara dengan ???", "Act10_6"),
        new QuestVariable(51, NPCidTranlate.Raya, "Bicara dengan si penjaga takdir?", "Act10_7"),


        // act 11
        new QuestVariable(52, NPCidTranlate.Anisa, "Bicara dengan anisa", "Act11_0"),
        new QuestVariable(53, NPCidTranlate.Raya, "Pergi ke hutan dan tinggalkan surat", "Act11_1"),


        // act 12
        new QuestVariable(54, NPCidTranlate.Anisa, "Bicara dengan anisa", "Act12_0"),
        new QuestVariable(55, NPCidTranlate.Anisa, "Kalahkan dia", "Act12_1"),
        new QuestVariable(56, NPCidTranlate.Raya, "lorem ipsum dolor sit amet consectetur adipiscing elit ipsum similique tempore duis velit consectetur", "Act12_2"),

    };
}
