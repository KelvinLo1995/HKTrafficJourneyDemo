using System;
using System.Collections.Generic;

namespace HKTrafficJourneyDemo
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://data.one.gov.hk/td")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://data.one.gov.hk/td", IsNullable = false)]
    public partial class jtis_journey_list
    {

        private List<jtis_journey_listJtis_journey_time> jtis_journey_timeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("jtis_journey_time")]
        public List<jtis_journey_listJtis_journey_time> jtis_journey_time
        {
            get
            {
                return this.jtis_journey_timeField;
            }
            set
            {
                this.jtis_journey_timeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://data.one.gov.hk/td")]
    public partial class jtis_journey_listJtis_journey_time
    {
        private List<Tuple<string, string>> LOCATION = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("H1","告士打道東行近稅務大樓的行車時間顯示器"),
            new Tuple<string, string>("H2","堅拿道天橋北行近香港仔隧道出口的行車時間顯示器"),
            new Tuple<string, string>("H3","東區走廊西行近城市花園的行車時間顯示器"),
            new Tuple<string, string>("H4","黃泥涌道北行近皇后大道東的行車時間顯示器"),
            new Tuple<string, string>("H5","興發街北行近維多利亞公園的行車時間顯示器"),
            new Tuple<string, string>("H6","淺水灣道北行近香島道的行車時間顯示器"),
            new Tuple<string, string>("H7","黃竹坑道北行近香港鄉村俱樂部的行車時間顯示器"),
            new Tuple<string, string>("H8","黃竹坑道東行近香港仔運動場的行車時間顯示器"),
            new Tuple<string, string>("H9","鴨脷洲橋道北行近黃竹坑道的行車時間顯示器"),
            new Tuple<string, string>("H11","東區走廊西行近鯉景灣的行車時間顯示器"),
            new Tuple<string, string>("K01","渡船街南行近富榮花園的行車時間顯示器"),
            new Tuple<string, string>("K02","加士居道東行近香港理工大學的行車時間顯示器"),
            new Tuple<string, string>("K03","窩打老道南行近九龍醫院的行車時間顯示器"),
            new Tuple<string, string>("K04","公主道南行近愛民邨的行車時間顯示器"),
            new Tuple<string, string>("K05","啟福道北行近油站的行車時間顯示器"),
            new Tuple<string, string>("K06","漆咸道北南行近佛光街遊樂場的行車時間顯示器"),
            new Tuple<string, string>("N01","洪天路南行近洪志路的行車時間顯示器"),
            new Tuple<string, string>("N02","朗天路南行近柏麗豪園的行車時間顯示器"),
            new Tuple<string, string>("N03","元朗公路東行近十八鄉交匯處的行車時間顯示器"),
            new Tuple<string, string>("N05","大埔公路東行近廣福邨的行車時間顯示器"),
            new Tuple<string, string>("N06","青沙公路西行近城門河道的行車時間顯示器"),
            new Tuple<string, string>("N07","福民路北行近普通道的行車時間顯示器"),
            new Tuple<string, string>("N08","寶順路南行近頌明苑的行車時間顯示器"),
            new Tuple<string, string>("N09","環保大道西行近香港單車館的行車時間顯示器"),
            new Tuple<string, string>("N10","寶康路南行近九巴將軍澳車廠的行車時間顯示器"),
            new Tuple<string, string>("N11","寶邑路西行近調景嶺體育館的行車時間顯示器"),
            new Tuple<string, string>("N12","寶順路南行近調景嶺體育館的行車時間顯示器"),
            new Tuple<string, string>("N13","翠嶺路東行近調景嶺體育館的行車時間顯示器"),
            new Tuple<string, string>("SJ1","大埔公路南行近沙田馬場的行車時間顯示器"),
            new Tuple<string, string>("SJ2","大老山隧道公路南行近石門的行車時間顯示器"),
            new Tuple<string, string>("SJ3","吐露港公路南行近科學園的行車時間顯示器"),
            new Tuple<string, string>("SJ4","新田公路南行近錦綉花園的行車時間顯示器"),
            new Tuple<string, string>("SJ5","屯門公路南行近井財街的行車時間顯示器"),
        };

        private List<Tuple<string, string>> DESTINIATION = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("CH","紅磡海底隧道"),
            new Tuple<string, string>("EH","東區海底隧道"),
            new Tuple<string, string>("WH","西區海底隧道"),
            new Tuple<string, string>("ABT","灣仔經香港仔隧道"),
            new Tuple<string, string>("WNCG","灣仔經黃泥涌峽道"),
            new Tuple<string, string>("PFL","中區經薄扶林道"),
            new Tuple<string, string>("TMCLK","機場經屯門赤鱲角隧道"),
            new Tuple<string, string>("ATL","機場經大欖隧道"),
            new Tuple<string, string>("SSCPR","上水經青山公路"),
            new Tuple<string, string>("SSYLH","上水經九號幹線"),
            new Tuple<string, string>("LRT","九龍(中)經獅子山隧道"),
            new Tuple<string, string>("SMT","荃灣經城門隧道"),
            new Tuple<string, string>("TCT","九龍(東)經大老山隧道"),
            new Tuple<string, string>("TKTL","汀九經大欖隧道"),
            new Tuple<string, string>("TKTM","汀九經屯門公路"),
            new Tuple<string, string>("TLH","沙田經吐露港公路"),
            new Tuple<string, string>("TPR","沙田經大埔公路"),
            new Tuple<string, string>("KTPR","九龍經大埔公路"),
            new Tuple<string, string>("TSCA","九龍(西)經八號幹線"),
            new Tuple<string, string>("TWCP","荃灣(西)經青山公路"),
            new Tuple<string, string>("TWTM","荃灣(西)經屯門公路"),
            new Tuple<string, string>("CWBR","九龍經清水灣道"),
            new Tuple<string, string>("MOS","九龍經二號幹線"),
            new Tuple<string, string>("TKOLTT","九龍經將軍澳藍田隧道"),
            new Tuple<string, string>("TKOT","九龍經將軍澳隧道"),
        };

        private string lOCATION_IDField;

        private string dESTINATION_IDField;

        private System.DateTime cAPTURE_DATEField;

        private int jOURNEY_TYPEField;

        private int jOURNEY_DATAField;

        private int cOLOUR_IDField;

        private string jOURNEY_DESCField;

        /// <remarks/>
        public string LOCATION_ID
        {
            get
            {
                return this.LOCATION.Find(dat => dat.Item1 == this.lOCATION_IDField).Item2;
            }
            set
            {
                this.lOCATION_IDField = value;
            }
        }

        /// <remarks/>
        public string DESTINATION_ID
        {
            get
            {
                return this.DESTINIATION.Find(dat => dat.Item1 == this.dESTINATION_IDField).Item2;
            }
            set
            {
                this.dESTINATION_IDField = value;
            }
        }

        /// <remarks/>
        public System.DateTime CAPTURE_DATE
        {
            get
            {
                return this.cAPTURE_DATEField;
            }
            set
            {
                this.cAPTURE_DATEField = value;
            }
        }

        /// <remarks/>
        public int JOURNEY_TYPE
        {
            get
            {
                return this.jOURNEY_TYPEField;
            }
            set
            {
                this.jOURNEY_TYPEField = value;
            }
        }

        /// <remarks/>
        public int JOURNEY_DATA
        {
            get
            {
                return this.jOURNEY_DATAField;
            }
            set
            {
                this.jOURNEY_DATAField = value;
            }
        }

        /// <remarks/>
        public int COLOUR_ID
        {
            get
            {
                return this.cOLOUR_IDField;
            }
            set
            {
                this.cOLOUR_IDField = value;
            }
        }

        /// <remarks/>
        public string JOURNEY_DESC
        {
            get
            {
                return this.jOURNEY_DESCField;
            }
            set
            {
                this.jOURNEY_DESCField = value;
            }
        }
    }
}
