--
-- PostgreSQL database dump
--

-- Dumped from database version 14.2
-- Dumped by pg_dump version 14.2

-- Started on 2023-06-04 21:41:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

SET TIME ZONE 'Europe/Zagreb';

--
-- TOC entry 210 (class 1259 OID 34269)
-- Name: Autocesta; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Autocesta" (
    "IdAutocesta" integer NOT NULL,
    "IdKoncesionar" integer NOT NULL,
    "NazivAutocesta" character varying(40) NOT NULL
);


ALTER TABLE public."Autocesta" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 34324)
-- Name: Cjenik; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Cjenik" (
    "IdCjenik" integer NOT NULL,
    "IdNaplatnaPostaja" integer NOT NULL,
    "IzlaznaPostaja" character varying(40) NOT NULL,
    "IakategorijaCijenaEuro" numeric(10,2) NOT NULL,
    "IkategorijaCijenaEuro" numeric(10,2) NOT NULL,
    "IikategorijaCijenaEuro" numeric(10,2) NOT NULL,
    "IiikategorijaCijenaEuro" numeric(10,2) NOT NULL,
    "IvkategorijaCijenaEuro" numeric(10,2) NOT NULL
);


ALTER TABLE public."Cjenik" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 34279)
-- Name: Dionica; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Dionica" (
    "IdDionica" integer NOT NULL,
    "IdAutocesta" integer NOT NULL,
    "NazivDionica" character varying(120) NOT NULL,
    "Kilometraža" numeric(10,3) NOT NULL,
    "BrojTraka" smallint NOT NULL
);


ALTER TABLE public."Dionica" OWNER TO postgres;

--
-- TOC entry 212 (class 1259 OID 34289)
-- Name: Dogadaj; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Dogadaj" (
    "IdDogadaj" integer NOT NULL,
    "IdDionica" integer NOT NULL,
    "MeteoroloskiUvjeti" character varying(40) NOT NULL,
    "OpisDogadaja" character varying(120) NOT NULL,
    "VrijemeDogadaja" timestamp without time zone NOT NULL,
    "Coordinates" character varying(500)
);


ALTER TABLE public."Dogadaj" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 34349)
-- Name: Encprolazak; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Encprolazak" (
    "IdProlaska" integer NOT NULL,
    "VrijemeProlaska" timestamp without time zone NOT NULL,
    "IdNaplatnaKucica" integer NOT NULL,
    "IdEnc" integer NOT NULL,
    "KategorijaVozila" character varying(3) NOT NULL
);


ALTER TABLE public."Encprolazak" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 34344)
-- Name: Encuredaj; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Encuredaj" (
    "IdEnc" integer NOT NULL,
    "BrojRacuna" character varying(14) NOT NULL,
    "StanjeNaRacunEuro" numeric(10,2) NOT NULL,
    "ImeVlasnika" character varying(30) NOT NULL,
    "EmailVlasnika" character varying(120) NOT NULL,
    "VrijediOd" date NOT NULL
);


ALTER TABLE public."Encuredaj" OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 34262)
-- Name: Koncesionar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Koncesionar" (
    "IdKoncesionar" integer NOT NULL,
    "NazivKoncesionar" character varying(120) NOT NULL,
    "Oibkoncesionar" character varying(13) NOT NULL,
    "TipKoncesionar" character varying(13) NOT NULL,
    "Adresa" character varying(120) NOT NULL,
    "NazivMjesto" character varying(40) NOT NULL,
    "Tel" character varying(13) NOT NULL,
    "Fax" character varying(13) NOT NULL,
    "Email" character varying(120) NOT NULL,
    "WebUrl" character varying(120) NOT NULL
);


ALTER TABLE public."Koncesionar" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 34334)
-- Name: NaplatnaKucica; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."NaplatnaKucica" (
    "IdNaplatnaKucica" integer NOT NULL,
    "IdNaplatnaPostaja" integer NOT NULL,
    "BrojStaze" smallint NOT NULL,
    "MinKategorijaVozila" character varying(3) NOT NULL,
    "MaxKategorijaVozila" character varying(3) NOT NULL,
    "OtvorenaNaplatnaKucica" character varying(1) NOT NULL,
    "PodrzavaEnc" character varying(1) NOT NULL,
    "NadoplataEnca" character varying(1) NOT NULL
);


ALTER TABLE public."NaplatnaKucica" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 34314)
-- Name: NaplatnaPostaja; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."NaplatnaPostaja" (
    "IdNaplatnaPostaja" integer NOT NULL,
    "NazivNaplatnaPostaja" character varying(40) NOT NULL,
    "NaplatnaPostajaKoordinateNs" character varying(40) NOT NULL,
    "NaplatnaPostajaKoordinateEw" character varying(40) NOT NULL,
    "Kontakt" character varying(120) NOT NULL,
    "IdAutocesta" integer
);


ALTER TABLE public."NaplatnaPostaja" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 34364)
-- Name: Objekt; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Objekt" (
    "IdObjekt" integer NOT NULL,
    "IdDionica" integer NOT NULL,
    "NazivObjekt" character varying(120) NOT NULL,
    "ObjektKoordinateNs" character varying(40) NOT NULL,
    "ObjektKoordinateEw" character varying(40) NOT NULL,
    "Tip" character varying(8) NOT NULL,
    "Podtip" character varying(100) NOT NULL,
    "NadmorskaVisina" integer NOT NULL,
    "Duljina" integer NOT NULL,
    "Opis" character varying(500) NOT NULL,
    "Stacionaza" numeric(10,3) NOT NULL
);


ALTER TABLE public."Objekt" OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 34376)
-- Name: Odmoriste; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Odmoriste" (
    "IdOdmoriste" integer NOT NULL,
    "NazivOdmoriste" character varying(40) NOT NULL,
    "Smjer" character varying(40) NOT NULL,
    "OdmoristeKoordinateNs" character varying(40) NOT NULL,
    "OdmoristeKoordinateEw" character varying(40) NOT NULL,
    "IdAutocesta" integer
);


ALTER TABLE public."Odmoriste" OWNER TO postgres;

--
-- TOC entry 223 (class 1259 OID 34391)
-- Name: Odrzavanje; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Odrzavanje" (
    "IdOdržavanje" integer NOT NULL,
    "IdObjekt" integer NOT NULL,
    "Vrijeme" timestamp without time zone NOT NULL,
    "Opis" character varying(200) NOT NULL,
    "IdVrstaOdrzavanja" integer NOT NULL,
    "Izvodac" character varying(120) NOT NULL
);


ALTER TABLE public."Odrzavanje" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 34304)
-- Name: Odziv; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Odziv" (
    "IdOdziv" integer NOT NULL,
    "IdVrstaOdziva" integer NOT NULL,
    "IdDogadaj" integer NOT NULL,
    "VrijemeOdziva" timestamp without time zone NOT NULL
);


ALTER TABLE public."Odziv" OWNER TO postgres;

--
-- TOC entry 225 (class 1259 OID 34411)
-- Name: PrateciSadrzaj; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PrateciSadrzaj" (
    "IdPratecegSadrzaja" integer NOT NULL,
    "NazivPratecegSadrzaja" character varying(120) NOT NULL,
    "IdOdmoriste" integer NOT NULL,
    "IdVrstaPratecegSadrzaja" integer NOT NULL,
    "RadnoVrijemeOd" time without time zone NOT NULL,
    "RadnoVrijemeDo" time without time zone NOT NULL
);


ALTER TABLE public."PrateciSadrzaj" OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 34386)
-- Name: VrstaOdrzavanja; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VrstaOdrzavanja" (
    "IdVrstaOdrzavanja" integer NOT NULL,
    "NazivVrsta" character varying(100) NOT NULL
);


ALTER TABLE public."VrstaOdrzavanja" OWNER TO postgres;

--
-- TOC entry 213 (class 1259 OID 34299)
-- Name: VrstaOdziva; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VrstaOdziva" (
    "IdVrstaOdziva" integer NOT NULL,
    "OpisOdziva" character varying(120) NOT NULL,
    "ImeOdziva" character varying(40) NOT NULL
);


ALTER TABLE public."VrstaOdziva" OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 34406)
-- Name: VrstaPratecegSadrzaja; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."VrstaPratecegSadrzaja" (
    "IdVrstaPratecegSadrzaja" integer NOT NULL,
    "NazivVrstePratecegSadrzaja" character varying(120) NOT NULL
);


ALTER TABLE public."VrstaPratecegSadrzaja" OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 34429)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 3422 (class 0 OID 34269)
-- Dependencies: 210
-- Data for Name: Autocesta; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Autocesta" ("IdAutocesta", "IdKoncesionar", "NazivAutocesta") FROM stdin;
1	1	A2 Zagreb - Macelj
2	2	A7 Rupa - Križišće
3	2	A8 Istarski ipsilon
4	2	A9 Istarski ipsilon
5	3	A1 Zagreb - Split - Dubrovnik
6	3	A3 Bregana - Zagreb - Lipovac
7	3	A4 Zagreb - Goričan
8	3	A5 Beli Manastir - Osijek - Svilaj
9	3	A6 Rijeka - Zagreb
10	3	A10 Granica BiH - Ploče
11	3	A11 Zagreb - Sisak
\.


--
-- TOC entry 3428 (class 0 OID 34324)
-- Dependencies: 216
-- Data for Name: Cjenik; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Cjenik" ("IdCjenik", "IdNaplatnaPostaja", "IzlaznaPostaja", "IakategorijaCijenaEuro", "IkategorijaCijenaEuro", "IikategorijaCijenaEuro", "IiikategorijaCijenaEuro", "IvkategorijaCijenaEuro") FROM stdin;
1	1	Zagreb	5.50	9.20	16.80	22.50	39.40
2	1	Zdenčina	5.00	8.30	15.20	20.30	35.50
3	2	Rijeka	11.00	12.00	11.00	12.00	13.00
\.


--
-- TOC entry 3423 (class 0 OID 34279)
-- Dependencies: 211
-- Data for Name: Dionica; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Dionica" ("IdDionica", "IdAutocesta", "NazivDionica", "Kilometraža", "BrojTraka") FROM stdin;
1	5	Žuta Lokva - Split	220.000	3
2	5	Split - Ploče	70.000	4
3	5	Ploce - Dubrovnik	130.000	2
4	10	Granicni prijelaz Nova Sela - cvor Ploce	8.500	3
5	11	Zagreb (Jakuševec) - Sisak	32.700	3
6	6	Bregana - Zagreb	66.400	2
7	6	Zagreb - Okucani	60.000	2
8	6	Okucani - Srednaci	60.000	2
9	8	Osijek - Srednaci	20.000	2
10	8	Srednaci - Svilaj	20.000	2
11	9	Bosiljevo - Rijeka	81.250	3
12	2	Rupa - Rijeka	14.000	3
13	2	Rijeka - Žuta Lokva	14.000	3
14	3	Kanfanar - Rijeka (Matulji)	64.200	2
15	4	Kaštel - Kanfanar	38.400	2
16	4	Kanfanar  - Pula	38.400	4
\.


--
-- TOC entry 3424 (class 0 OID 34289)
-- Dependencies: 212
-- Data for Name: Dogadaj; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Dogadaj" ("IdDogadaj", "IdDionica", "MeteoroloskiUvjeti", "OpisDogadaja", "VrijemeDogadaja", "Coordinates") FROM stdin;
2	9	Maglovito	Sudar dvaju osobnih vozila u tunelu Tuhobic.	2022-03-09 17:25:03	(14.805523,45.386945)
1	6	Povremeni pljuskovi	Sudar dvaju teretnih vozila na dionici Bregana - Zagreb.	2022-03-09 17:25:03	(16.176143,45.788065)
3	1	Pretežno oblačno	Vozilo u suprotnom smjeru.	2022-07-06 07:03:11	(15.864273,46.072766)
4	3	Sunčano	Vozilo u kvaru.	2022-07-06 07:03:11	(13.623739,45.340991)
8	5	Suncano	Radovi na autocesti	2023-05-05 14:10:00	(16.822138,43.479068)
9	1	Suncano	Vozilo u kvaru	2023-05-11 20:45:00	(16.979370117187504,43.33629038232279)
5	1	Oblačno	Radovi na autocesti..	2023-01-06 12:09:00	(15.864273,46.138265)
10	6	Oblačno	Radovi na autocesti..	2023-05-07 23:09:00	(15.419311523437502,45.670804183942884)
11	15	Oblačno	Požar 	2023-05-04 16:39:00	(16.506958678364757,43.352269832012105)
12	9	Oblačno	Požar 	2023-05-14 16:53:00	(14.8480224609375,44.56222116613944)
\.


--
-- TOC entry 3431 (class 0 OID 34349)
-- Dependencies: 219
-- Data for Name: Encprolazak; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Encprolazak" ("IdProlaska", "VrijemeProlaska", "IdNaplatnaKucica", "IdEnc", "KategorijaVozila") FROM stdin;
1	2022-01-01 01:01:11	1	1	II
2	2022-01-01 01:01:11	2	2	II
\.


--
-- TOC entry 3430 (class 0 OID 34344)
-- Dependencies: 218
-- Data for Name: Encuredaj; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Encuredaj" ("IdEnc", "BrojRacuna", "StanjeNaRacunEuro", "ImeVlasnika", "EmailVlasnika", "VrijediOd") FROM stdin;
1	61926631074518	760.00	Franka Kovacic	franka.kovacic@gmail.com	2018-07-11
2	61926631074518	760.00	Petar Grašo	PetarGrašo9@gmail.com	2010-03-01
\.


--
-- TOC entry 3421 (class 0 OID 34262)
-- Dependencies: 209
-- Data for Name: Koncesionar; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Koncesionar" ("IdKoncesionar", "NazivKoncesionar", "Oibkoncesionar", "TipKoncesionar", "Adresa", "NazivMjesto", "Tel", "Fax", "Email", "WebUrl") FROM stdin;
1	Autocesta Zagreb - Macelj d.o.o.	82667270868	Pravna osoba	Garicgradska 18	Zagreb	+38513689600	+38513689620	office@azm.hr	http://www.azm.hr/
2	Bina-Istra d.d.	13439120211	Pravna osoba	Zrinščak 57	Lupoglav	+38516138300	+38516138301	bina-ista1@pu.t-com.hr	http://bina-istra.com/
3	Hrvatske autoceste d.o.o.	57500462912	Pravna osoba	Širolina 4	Zagreb	+38514694444	+38514694500	info@hac.hr	http://hac.hr/
\.


--
-- TOC entry 3429 (class 0 OID 34334)
-- Dependencies: 217
-- Data for Name: NaplatnaKucica; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."NaplatnaKucica" ("IdNaplatnaKucica", "IdNaplatnaPostaja", "BrojStaze", "MinKategorijaVozila", "MaxKategorijaVozila", "OtvorenaNaplatnaKucica", "PodrzavaEnc", "NadoplataEnca") FROM stdin;
1	3	3	IA	III	T	T	T
2	1	2	I	III	F	T	T
3	1	4	III	II	F	T	F
4	1	5	III	IV	T	T	F
5	2	4	IA	II	F	T	F
\.


--
-- TOC entry 3427 (class 0 OID 34314)
-- Dependencies: 215
-- Data for Name: NaplatnaPostaja; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."NaplatnaPostaja" ("IdNaplatnaPostaja", "NazivNaplatnaPostaja", "NaplatnaPostajaKoordinateNs", "NaplatnaPostajaKoordinateEw", "Kontakt", "IdAutocesta") FROM stdin;
1	Zagreb (Lučko)	45.74904	15.88420	prodaja.lucko@hac.hr	5
2	Donja Zdenčina	45.67537	15.75648	-	5
3	Jastrebarsko	45.84540	15.70378	-	5
4	Karlovac	45.51235	15.54846	-	5
5	Novigrad	45.47943	15.42565	-	5
6	Bosiljevo 1	45.83932	15.70465	prodaja.bregana@hac.hr	5
7	Zadar Istok	44.12446	15.43867	prodaja.zada@hac.hrr	5
8	Zadar Centar	44.19983	15.42906	-	5
9	Lekenik	45.21457	17.20982	-	11
10	Buševec	45.62241	16.10851	-	11
\.


--
-- TOC entry 3432 (class 0 OID 34364)
-- Dependencies: 220
-- Data for Name: Objekt; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Objekt" ("IdObjekt", "IdDionica", "NazivObjekt", "ObjektKoordinateNs", "ObjektKoordinateEw", "Tip", "Podtip", "NadmorskaVisina", "Duljina", "Opis", "Stacionaza") FROM stdin;
1	6	Nadvožnjak Lekenik	45.572064NS	16.287771EW	Most	Nadvožnjak	110	500	Nalazi se na dionici Bregana-Lipovac između čvorova Velika Gorica i Lekenik, na nadmorskoj visini 110m, duljina mu je oko 500m, često se spominje kao zanimljiv turistički objekt i vidikovac.	7.160
2	5	Tunel Orlovac	45.726992NS	16.145584EW	Tunel	Tunel	105	500	Tunel Orlovac se nalazi na dionici Zagreb - Sisak, a otvoren je 2009. godine. Predstavlja jedan od najdužih tunela u Hrvatskoj.	7.160
3	9	Most Drava	45.726992NS	16.145584EW	Most	Most	23	474	Most Drava se nalazi na dionici Osijek - Đakovo - Sredanci, a otvoren je 2008. godine. Jedan je od najduljih mostova u Hrvatskoj. 	7.160
4	12	Tunel Tuhobić	45.082750NS	15.550678EW	Tunel	Tunel	500	5779	Tunel Tuhobić se nalazi na dionici Rijeka - Zagreb, a otvoren je 2004. godine. Tunel je dug 5,8 km i predstavlja jedan od najdužih tunela u Hrvatskoj. 	7.160
\.


--
-- TOC entry 3433 (class 0 OID 34376)
-- Dependencies: 221
-- Data for Name: Odmoriste; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Odmoriste" ("IdOdmoriste", "NazivOdmoriste", "Smjer", "OdmoristeKoordinateNs", "OdmoristeKoordinateEw", "IdAutocesta") FROM stdin;
1	Stupnik	Split	45.74550	15.88068	5
2	Desinec	Zagreb	45.66314	15.71083	5
3	Draganić	Zagreb	45.55989	15.60743	5
4	Draganić	Split	45.55799	15.60770	5
25	Mosor	Split	43.49271	16.78315	5
26	Gradna	Bregana	45.82700	15.73859	6
27	Gradna	Lipovac	45.82594	15.73768	6
28	Zagreb	Bregana	45.7747	15.88029	6
29	Zagreb	Lipovac	45.77480	15.87837	6
30	Novoselec	Bregana	45.63747	16.51351	6
31	Novoselec	Lipovac	45.63925	16.50919	6
32	Sava	Bregana	45.10916	18.52619	6
33	Sava	Lipovac	45.10814	18.52354	6
34	Bošnjaci	Bregana	45.05693	18.81262	6
35	Bošnjaci	Lipovac	45.05755	18.81326	6
36	Ljubešćica	Zagreb	46.16968	16.37560	7
37	Ljubešćica	Goričan	46.16945	16.37438	7
38	Ivandvor	Svilaj	45.27217	18.34696	8
39	Ivandvor	Beli Manastir	45.27193	18.34846	8
40	Kupjak	Oba smjera	45.38211	14.93554	9
41	Tuhobić	Oba smjera	45.32221	14.62571	9
42	Lepenica	Oba smjera	45.32714	14.65707	9
43	Pojezerje	Oba smjera	43.13709	17.505540	10
\.


--
-- TOC entry 3435 (class 0 OID 34391)
-- Dependencies: 223
-- Data for Name: Odrzavanje; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Odrzavanje" ("IdOdržavanje", "IdObjekt", "Vrijeme", "Opis", "IdVrstaOdrzavanja", "Izvodac") FROM stdin;
1	1	2023-03-02 11:00:00	opis	3	Hrvatske autoceste d.o.o.
2	2	2013-03-05 10:30:00	opis	1	Hrvatske autoceste d.o.o.
\.


--
-- TOC entry 3426 (class 0 OID 34304)
-- Dependencies: 214
-- Data for Name: Odziv; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Odziv" ("IdOdziv", "IdVrstaOdziva", "IdDogadaj", "VrijemeOdziva") FROM stdin;
1	1	1	2021-04-04 16:52:05
2	2	2	2022-03-09 17:43:00
\.


--
-- TOC entry 3437 (class 0 OID 34411)
-- Dependencies: 225
-- Data for Name: PrateciSadrzaj; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."PrateciSadrzaj" ("IdPratecegSadrzaja", "NazivPratecegSadrzaja", "IdOdmoriste", "IdVrstaPratecegSadrzaja", "RadnoVrijemeOd", "RadnoVrijemeDo") FROM stdin;
1	Crodux A1 Stupnik	1	1	00:00:00	24:00:00
2	Odmorište Stupnik - toalet	1	8	00:00:00	24:00:00
3	Trgovina Crodux 	1	4	00:00:00	24:00:00
4	Atlantida Caffe Bar	1	6	00:00:00	24:00:00
5	Parking Stupnik	1	10	00:00:00	24:00:00
6	INA Desinec	2	1	00:00:00	24:00:00
7	Trgovina INA Desinec	2	4	00:00:00	24:00:00
8	Restoran Desinec	2	2	05:00:00	23:00:00
9	Caffe Bar KOBAN	2	6	06:00:00	23:00:00
10	Parking Odmorište Desinec	2	10	00:00:00	24:00:00
11	Toalet Desenec	2	8	00:00:00	24:00:00
12	Tuš Desinec	2	9	00:00:00	24:00:00
13	Trgovina INA Draganić	3	4	00:00:00	24:00:00
14	Restoran Draganić	3	2	05:00:00	23:00:00
15	Caffe Bar KOBAN	3	6	06:00:00	23:00:00
16	Parking Odmorište Draganić	3	10	00:00:00	24:00:00
17	Toalet Draganić	3	8	00:00:00	24:00:00
18	Tuš Draganić	3	9	00:00:00	24:00:00
19	Petrol	3	1	00:00:00	24:00:00
20	Draganić Hostel	3	7	00:00:00	24:00:00
21	Trgovina Petrol Draganić	4	4	00:00:00	24:00:00
22	Restoran Draganić	4	2	05:00:00	23:00:00
23	Caffe Bar KOBAN	4	6	06:00:00	23:00:00
24	Parking Odmorište Draganić	4	10	00:00:00	24:00:00
25	Toalet Draganić	4	8	00:00:00	24:00:00
26	Tuš Draganić	4	9	00:00:00	24:00:00
27	Petrol	4	1	00:00:00	24:00:00
28	Draganić Hostel	4	7	00:00:00	24:00:00
29	Trgovina INA Mosor	25	4	00:00:00	24:00:00
30	Restoran Mosor	25	2	05:00:00	23:00:00
31	Caffe Bar KOBAN	25	6	06:00:00	23:00:00
32	Parking Odmorište Mosor	25	10	00:00:00	24:00:00
33	Toalet Mosor	25	8	00:00:00	24:00:00
34	Tuš Mosor	25	9	00:00:00	24:00:00
36	Mosor Hostel	25	7	00:00:00	24:00:00
37	Dječje igralište Mosor	25	3	00:00:00	24:00:00
38	INA Benzinska Postaja Mosor A1	25	1	00:00:00	24:00:00
39	PBZ Bankomat	1	12	00:00:00	24:00:00
40	OTP Bankomat	2	12	00:00:00	24:00:00
41	OTP Bankomat	3	12	00:00:00	24:00:00
43	Mjenjacnica	2	11	07:00:00	23:00:00
47	Punionica za elektricna vozila	1	5	00:00:00	24:00:00
48	Punionica za elektricna vozila	2	5	00:00:00	24:00:00
51	Dječje igralište	4	3	06:00:00	23:00:00
45	Autopraonica	41	13	00:00:00	24:00:00
46	Autopraonica	37	13	00:00:00	24:00:00
52	Autopraonica	4	13	00:00:00	24:00:00
53	Autopraonica	36	13	00:00:00	24:00:00
54	Autopraonica	1	13	00:00:00	24:00:00
\.


--
-- TOC entry 3434 (class 0 OID 34386)
-- Dependencies: 222
-- Data for Name: VrstaOdrzavanja; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VrstaOdrzavanja" ("IdVrstaOdrzavanja", "NazivVrsta") FROM stdin;
1	Redovno
2	Neredovno
3	Izvanredno
\.


--
-- TOC entry 3425 (class 0 OID 34299)
-- Dependencies: 213
-- Data for Name: VrstaOdziva; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VrstaOdziva" ("IdVrstaOdziva", "OpisOdziva", "ImeOdziva") FROM stdin;
1	Ostecena vozila su zbrinuta, ozlijedenima je pruzena hitna pomoc.	Intervencija hitne pomoci i vatrogasaca.
2	Promet se vodi dvosmjerno na kolniku u smjeru Zagreba.	Privremena prometna signalizacija.
3	Promet se vodi dvosmjerno na kolniku u smjeru Rijeke.	Privremena prometna signalizacija.
4	Zbog ostecenja elasticne odbojne ograde na autocesti vozi se uz ogranicenje brzine 80km/h u oba smjera.	Izvanredni događaj.
\.


--
-- TOC entry 3436 (class 0 OID 34406)
-- Dependencies: 224
-- Data for Name: VrstaPratecegSadrzaja; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."VrstaPratecegSadrzaja" ("IdVrstaPratecegSadrzaja", "NazivVrstePratecegSadrzaja") FROM stdin;
1	Benzinska postaja
2	Restoran
3	Igralište
4	Trgovina
5	Punionica za elektricna vozila
6	Caffe bar
7	Spavanje
8	Toalet
9	Tuš
10	Parking
11	Mjenjacnica
12	Bankomat
13	Autopraonica
\.


--
-- TOC entry 3438 (class 0 OID 34429)
-- Dependencies: 226
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
\.


--
-- TOC entry 3266 (class 2606 OID 34433)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3234 (class 2606 OID 34273)
-- Name: Autocesta autocesta_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autocesta"
    ADD CONSTRAINT autocesta_pkey PRIMARY KEY ("IdAutocesta");


--
-- TOC entry 3246 (class 2606 OID 34328)
-- Name: Cjenik cjenik_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cjenik"
    ADD CONSTRAINT cjenik_pkey PRIMARY KEY ("IdCjenik");


--
-- TOC entry 3236 (class 2606 OID 34283)
-- Name: Dionica dionica_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Dionica"
    ADD CONSTRAINT dionica_pkey PRIMARY KEY ("IdDionica");


--
-- TOC entry 3238 (class 2606 OID 34293)
-- Name: Dogadaj dogadaj_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Dogadaj"
    ADD CONSTRAINT dogadaj_pkey PRIMARY KEY ("IdDogadaj");


--
-- TOC entry 3252 (class 2606 OID 34353)
-- Name: Encprolazak encprolazak_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Encprolazak"
    ADD CONSTRAINT encprolazak_pkey PRIMARY KEY ("IdProlaska");


--
-- TOC entry 3250 (class 2606 OID 34348)
-- Name: Encuredaj encuredaj_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Encuredaj"
    ADD CONSTRAINT encuredaj_pkey PRIMARY KEY ("IdEnc");


--
-- TOC entry 3232 (class 2606 OID 34268)
-- Name: Koncesionar koncesionar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Koncesionar"
    ADD CONSTRAINT koncesionar_pkey PRIMARY KEY ("IdKoncesionar");


--
-- TOC entry 3248 (class 2606 OID 34338)
-- Name: NaplatnaKucica naplatnakucica_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."NaplatnaKucica"
    ADD CONSTRAINT naplatnakucica_pkey PRIMARY KEY ("IdNaplatnaKucica");


--
-- TOC entry 3244 (class 2606 OID 34318)
-- Name: NaplatnaPostaja naplatnapostaja_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."NaplatnaPostaja"
    ADD CONSTRAINT naplatnapostaja_pkey PRIMARY KEY ("IdNaplatnaPostaja");


--
-- TOC entry 3254 (class 2606 OID 34370)
-- Name: Objekt objekt_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Objekt"
    ADD CONSTRAINT objekt_pkey PRIMARY KEY ("IdObjekt");


--
-- TOC entry 3256 (class 2606 OID 34380)
-- Name: Odmoriste odmoriste_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odmoriste"
    ADD CONSTRAINT odmoriste_pkey PRIMARY KEY ("IdOdmoriste");


--
-- TOC entry 3260 (class 2606 OID 34395)
-- Name: Odrzavanje odrzavanje_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odrzavanje"
    ADD CONSTRAINT odrzavanje_pkey PRIMARY KEY ("IdOdržavanje");


--
-- TOC entry 3242 (class 2606 OID 34308)
-- Name: Odziv odziv_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odziv"
    ADD CONSTRAINT odziv_pkey PRIMARY KEY ("IdOdziv");


--
-- TOC entry 3264 (class 2606 OID 34417)
-- Name: PrateciSadrzaj pratecisadrzaj_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PrateciSadrzaj"
    ADD CONSTRAINT pratecisadrzaj_pkey PRIMARY KEY ("IdPratecegSadrzaja");


--
-- TOC entry 3258 (class 2606 OID 34390)
-- Name: VrstaOdrzavanja vrstaodrzavanja_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VrstaOdrzavanja"
    ADD CONSTRAINT vrstaodrzavanja_pkey PRIMARY KEY ("IdVrstaOdrzavanja");


--
-- TOC entry 3240 (class 2606 OID 34303)
-- Name: VrstaOdziva vrstaodziva_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VrstaOdziva"
    ADD CONSTRAINT vrstaodziva_pkey PRIMARY KEY ("IdVrstaOdziva");


--
-- TOC entry 3262 (class 2606 OID 34410)
-- Name: VrstaPratecegSadrzaja vrstapratecegsadrzaja_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."VrstaPratecegSadrzaja"
    ADD CONSTRAINT vrstapratecegsadrzaja_pkey PRIMARY KEY ("IdVrstaPratecegSadrzaja");


--
-- TOC entry 3268 (class 2606 OID 34284)
-- Name: Dionica Dionica_IdAutocesta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Dionica"
    ADD CONSTRAINT "Dionica_IdAutocesta_fkey" FOREIGN KEY ("IdAutocesta") REFERENCES public."Autocesta"("IdAutocesta");


--
-- TOC entry 3269 (class 2606 OID 34294)
-- Name: Dogadaj Dogadaj_IdDionica_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Dogadaj"
    ADD CONSTRAINT "Dogadaj_IdDionica_fkey" FOREIGN KEY ("IdDionica") REFERENCES public."Dionica"("IdDionica");


--
-- TOC entry 3267 (class 2606 OID 34274)
-- Name: Autocesta autocesta_idkoncesionar_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Autocesta"
    ADD CONSTRAINT autocesta_idkoncesionar_fkey FOREIGN KEY ("IdKoncesionar") REFERENCES public."Koncesionar"("IdKoncesionar");


--
-- TOC entry 3272 (class 2606 OID 34329)
-- Name: Cjenik cjenik_idnaplatnapostaja_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Cjenik"
    ADD CONSTRAINT cjenik_idnaplatnapostaja_fkey FOREIGN KEY ("IdNaplatnaPostaja") REFERENCES public."NaplatnaPostaja"("IdNaplatnaPostaja");


--
-- TOC entry 3275 (class 2606 OID 34359)
-- Name: Encprolazak encprolazak_idenc_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Encprolazak"
    ADD CONSTRAINT encprolazak_idenc_fkey FOREIGN KEY ("IdEnc") REFERENCES public."Encuredaj"("IdEnc");


--
-- TOC entry 3274 (class 2606 OID 34354)
-- Name: Encprolazak encprolazak_idnaplatnakucica_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Encprolazak"
    ADD CONSTRAINT encprolazak_idnaplatnakucica_fkey FOREIGN KEY ("IdNaplatnaKucica") REFERENCES public."NaplatnaKucica"("IdNaplatnaKucica");


--
-- TOC entry 3273 (class 2606 OID 34339)
-- Name: NaplatnaKucica naplatnakucica_idnaplatnapostaja_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."NaplatnaKucica"
    ADD CONSTRAINT naplatnakucica_idnaplatnapostaja_fkey FOREIGN KEY ("IdNaplatnaPostaja") REFERENCES public."NaplatnaPostaja"("IdNaplatnaPostaja");


--
-- TOC entry 3271 (class 2606 OID 34456)
-- Name: NaplatnaPostaja naplatnapostaja_idautocesta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."NaplatnaPostaja"
    ADD CONSTRAINT naplatnapostaja_idautocesta_fkey FOREIGN KEY ("IdAutocesta") REFERENCES public."Autocesta"("IdAutocesta");


--
-- TOC entry 3276 (class 2606 OID 34371)
-- Name: Objekt objekt_iddionica_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Objekt"
    ADD CONSTRAINT objekt_iddionica_fkey FOREIGN KEY ("IdDionica") REFERENCES public."Dionica"("IdDionica");


--
-- TOC entry 3277 (class 2606 OID 34451)
-- Name: Odmoriste odmoriste_idautocesta_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odmoriste"
    ADD CONSTRAINT odmoriste_idautocesta_fkey FOREIGN KEY ("IdAutocesta") REFERENCES public."Autocesta"("IdAutocesta");


--
-- TOC entry 3278 (class 2606 OID 34396)
-- Name: Odrzavanje odrzavanje_idobjekt_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odrzavanje"
    ADD CONSTRAINT odrzavanje_idobjekt_fkey FOREIGN KEY ("IdObjekt") REFERENCES public."Objekt"("IdObjekt");


--
-- TOC entry 3279 (class 2606 OID 34401)
-- Name: Odrzavanje odrzavanje_idvrstaodrzavanja_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odrzavanje"
    ADD CONSTRAINT odrzavanje_idvrstaodrzavanja_fkey FOREIGN KEY ("IdVrstaOdrzavanja") REFERENCES public."VrstaOdrzavanja"("IdVrstaOdrzavanja");


--
-- TOC entry 3270 (class 2606 OID 34309)
-- Name: Odziv odziv_idvrstaodziva_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Odziv"
    ADD CONSTRAINT odziv_idvrstaodziva_fkey FOREIGN KEY ("IdVrstaOdziva") REFERENCES public."VrstaOdziva"("IdVrstaOdziva");


--
-- TOC entry 3281 (class 2606 OID 34423)
-- Name: PrateciSadrzaj pratecisadrzaj_idodmoriste_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PrateciSadrzaj"
    ADD CONSTRAINT pratecisadrzaj_idodmoriste_fkey FOREIGN KEY ("IdOdmoriste") REFERENCES public."Odmoriste"("IdOdmoriste");


--
-- TOC entry 3280 (class 2606 OID 34418)
-- Name: PrateciSadrzaj pratecisadrzaj_idvrstapratecegsadrzaja_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PrateciSadrzaj"
    ADD CONSTRAINT pratecisadrzaj_idvrstapratecegsadrzaja_fkey FOREIGN KEY ("IdVrstaPratecegSadrzaja") REFERENCES public."VrstaPratecegSadrzaja"("IdVrstaPratecegSadrzaja");


-- Completed on 2023-06-04 21:41:38

--
-- PostgreSQL database dump complete
--

