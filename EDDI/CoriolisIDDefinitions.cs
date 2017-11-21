﻿using System.Collections.Generic;
using Utilities;

namespace Eddi
{
    public class CoriolisIDDefinitions
    {
        private static Dictionary<long, string> CoriolisIDs = new Dictionary<long, string>
        {
            { 100, "kp"},
            { 738, "b0"},
            { 739, "b1"},
            { 740, "b2"},
            { 741, "b3"},
            { 742, "b4"},
            { 743, "bY"},
            { 744, "bZ"},
            { 745, "B0"},
            { 746, "B1"},
            { 747, "B2"},
            { 748, "Bi"},
            { 749, "Bj"},
            { 750, "Bk"},
            { 751, "Bl"},
            { 752, "Bm"},
            { 753, "BC"},
            { 754, "BD"},
            { 755, "BE"},
            { 756, "BF"},
            { 757, "BG"},
            { 758, "B3"},
            { 759, "B4"},
            { 760, "B5"},
            { 761, "B6"},
            { 762, "B7"},
            { 763, "bk"},
            { 764, "bl"},
            { 765, "bm"},
            { 766, "bn"},
            { 767, "bo"},
            { 768, "Bn"},
            { 769, "Bo"},
            { 770, "Bp"},
            { 771, "Bq"},
            { 772, "Br"},
            { 773, "Bs"},
            { 774, "Bt"},
            { 775, "Bu"},
            { 776, "Bv"},
            { 777, "Bw"},
            { 778, "BH"},
            { 779, "BI"},
            { 780, "BJ"},
            { 781, "BK"},
            { 782, "BL"},
            { 783, "B8"},
            { 784, "B9"},
            { 785, "Ba"},
            { 786, "Bb"},
            { 787, "Bc"},
            { 788, "bp"},
            { 789, "bq"},
            { 790, "br"},
            { 791, "bs"},
            { 792, "bt"},
            { 793, "bE"},
            { 794, "bF"},
            { 795, "bG"},
            { 796, "bH"},
            { 797, "bI"},
            { 798, "BM"},
            { 799, "BN"},
            { 800, "BO"},
            { 801, "BP"},
            { 802, "BQ"},
            { 803, "Bx"},
            { 804, "By"},
            { 805, "Bz"},
            { 806, "BA"},
            { 807, "BB"},
            { 808, "bO"},
            { 809, "bP"},
            { 810, "bQ"},
            { 811, "bR"},
            { 812, "bS"},
            { 813, "Bd"},
            { 814, "Be"},
            { 815, "Bf"},
            { 816, "Bg"},
            { 817, "Bh"},
            { 818, "bT"},
            { 819, "bU"},
            { 820, "bV"},
            { 821, "bW"},
            { 822, "bX"},
            { 823, "17"},
            { 824, "1a"},
            { 825, "1d"},
            { 826, "18"},
            { 827, "1b"},
            { 828, "1e"},
            { 829, "19"},
            { 830, "1c"},
            { 831, "1f"},
            { 832, "11"},
            { 833, "7h"},
            { 834, "14"},
            { 835, "12"},
            { 836, "7i"},
            { 837, "15"},
            { 838, "13"},
            { 839, "7j"},
            { 840, "16"},
            { 841, "10"},
            { 842, "0r"},
            { 843, "0u"},
            { 844, "0p"},
            { 845, "0s"},
            { 846, "0v"},
            { 847, "0q"},
            { 848, "0t"},
            { 849, "0o"},
            { 850, "1h"},
            { 851, "1k"},
            { 852, "1n"},
            { 853, "1q"},
            { 854, "1i"},
            { 855, "1l"},
            { 856, "1r"},
            { 857, "1j"},
            { 858, "1m"},
            { 859, "1p"},
            { 860, "20"},
            { 861, "1s"},
            { 862, "1t"},
            { 863, "21"},
            { 864, "7e"},
            { 865, "22"},
            { 866, "7f"},
            { 867, "23"},
            { 868, "26"},
            { 869, "24"},
            { 870, "27"},
            { 871, "25"},
            { 872, "28"},
            { 873, "1g"},
            { 874, "2b"},
            { 875, "2c"},
            { 876, "29"},
            { 877, "2a"},
            { 878, "2e"},
            { 879, "2g"},
            { 880, "2j"},
            { 881, "2k"},
            { 882, "2h"},
            { 883, "2i"},
            { 884, "00"},
            { 885, "01"},
            { 886, "02"},
            { 887, "03"},
            { 888, "2l"},
            { 889, "2m"},
            { 890, "24"},
            { 891, "p4"},
            { 892, "p3"},
            { 893, "p2"},
            { 894, "p1"},
            { 895, "p0"},
            { 896, "p9"},
            { 897, "p8"},
            { 898, "p7"},
            { 899, "p6"},
            { 900, "p5"},
            { 901, "pe"},
            { 902, "pd"},
            { 903, "pc"},
            { 904, "pb"},
            { 905, "pa"},
            { 906, "pj"},
            { 907, "pi"},
            { 908, "ph"},
            { 909, "pg"},
            { 910, "pf"},
            { 911, "po"},
            { 912, "pn"},
            { 913, "pm"},
            { 914, "pl"},
            { 915, "pk"},
            { 916, "pt"},
            { 917, "ps"},
            { 918, "pr"},
            { 919, "pq"},
            { 920, "pp"},
            { 921, "py"},
            { 922, "px"},
            { 923, "pw"},
            { 924, "pv"},
            { 925, "pu"},
            { 926, "t4"},
            { 927, "t3"},
            { 928, "t2"},
            { 929, "t1"},
            { 930, "t0"},
            { 931, "t9"},
            { 932, "t8"},
            { 933, "t7"},
            { 934, "t6"},
            { 935, "t5"},
            { 936, "te"},
            { 937, "td"},
            { 938, "tc"},
            { 939, "tb"},
            { 940, "ta"},
            { 941, "tj"},
            { 942, "ti"},
            { 943, "th"},
            { 944, "tg"},
            { 945, "tf"},
            { 946, "to"},
            { 947, "tn"},
            { 948, "tm"},
            { 949, "tl"},
            { 950, "tk"},
            { 951, "tt"},
            { 952, "ts"},
            { 953, "tr"},
            { 954, "tq"},
            { 955, "tp"},
            { 956, "ty"},
            { 957, "tx"},
            { 958, "tw"},
            { 959, "tv"},
            { 960, "tu"},
            { 961, "F4"},
            { 962, "F3"},
            { 963, "F2"},
            { 964, "F1"},
            { 965, "F0"},
            { 966, "F9"},
            { 967, "F8"},
            { 968, "F7"},
            { 969, "F6"},
            { 970, "F5"},
            { 971, "Fe"},
            { 972, "Fd"},
            { 973, "Fc"},
            { 974, "Fb"},
            { 975, "Fa"},
            { 976, "Fj"},
            { 977, "Fi"},
            { 978, "Fh"},
            { 979, "Fg"},
            { 980, "Ff"},
            { 981, "Fo"},
            { 982, "Fn"},
            { 983, "Fm"},
            { 984, "Fl"},
            { 985, "Fk"},
            { 986, "Ft"},
            { 987, "Fs"},
            { 988, "Fr"},
            { 989, "Fq"},
            { 990, "Fp"},
            { 991, "Fy"},
            { 992, "Fx"},
            { 993, "Fw"},
            { 994, "Fv"},
            { 995, "Fu"},
            { 996, "l4"},
            { 997, "l3"},
            { 998, "l2"},
            { 999, "l1"},
            { 1000, "l0"},
            { 1001, "l9"},
            { 1002, "l8"},
            { 1003, "l7"},
            { 1004, "l6"},
            { 1005, "l5"},
            { 1006, "le"},
            { 1007, "ld"},
            { 1008, "lc"},
            { 1009, "lb"},
            { 1010, "la"},
            { 1011, "lj"},
            { 1012, "li"},
            { 1013, "lh"},
            { 1014, "lg"},
            { 1015, "lf"},
            { 1016, "lo"},
            { 1017, "ln"},
            { 1018, "lm"},
            { 1019, "ll"},
            { 1020, "lk"},
            { 1021, "lt"},
            { 1022, "ls"},
            { 1023, "lr"},
            { 1024, "lq"},
            { 1025, "lp"},
            { 1026, "ly"},
            { 1027, "lx"},
            { 1028, "lw"},
            { 1029, "lv"},
            { 1030, "lu"},
            { 1031, "lD"},
            { 1032, "lC"},
            { 1033, "lB"},
            { 1034, "lA"},
            { 1035, "lz"},
            { 1036, "d4"},
            { 1037, "d3"},
            { 1038, "d2"},
            { 1039, "d1"},
            { 1040, "d0"},
            { 1041, "d9"},
            { 1042, "d8"},
            { 1043, "d7"},
            { 1044, "d6"},
            { 1045, "d5"},
            { 1046, "de"},
            { 1047, "dd"},
            { 1048, "dc"},
            { 1049, "db"},
            { 1050, "da"},
            { 1051, "dj"},
            { 1052, "di"},
            { 1053, "dh"},
            { 1054, "dg"},
            { 1055, "df"},
            { 1056, "do"},
            { 1057, "dn"},
            { 1058, "dm"},
            { 1059, "dl"},
            { 1060, "dk"},
            { 1061, "dt"},
            { 1062, "ds"},
            { 1063, "dr"},
            { 1064, "dq"},
            { 1065, "dp"},
            { 1066, "dy"},
            { 1067, "dx"},
            { 1068, "dw"},
            { 1069, "dv"},
            { 1070, "du"},
            { 1071, "dD"},
            { 1072, "dC"},
            { 1073, "dB"},
            { 1074, "dA"},
            { 1075, "dz"},
            { 1076, "s4"},
            { 1077, "s3"},
            { 1078, "s2"},
            { 1079, "s1"},
            { 1080, "s0"},
            { 1081, "s9"},
            { 1082, "s8"},
            { 1083, "s7"},
            { 1084, "s6"},
            { 1085, "s5"},
            { 1086, "se"},
            { 1087, "sd"},
            { 1088, "sc"},
            { 1089, "sb"},
            { 1090, "sa"},
            { 1091, "sj"},
            { 1092, "si"},
            { 1093, "sh"},
            { 1094, "sg"},
            { 1095, "sf"},
            { 1096, "so"},
            { 1097, "sn"},
            { 1098, "sm"},
            { 1099, "sl"},
            { 1100, "sk"},
            { 1101, "st"},
            { 1102, "ss"},
            { 1103, "sr"},
            { 1104, "sq"},
            { 1105, "sp"},
            { 1106, "sD"},
            { 1107, "sC"},
            { 1108, "sB"},
            { 1109, "sA"},
            { 1110, "sz"},
            { 1111, "sy"},
            { 1112, "sx"},
            { 1113, "sw"},
            { 1114, "sv"},
            { 1115, "su"},
            { 1116, "3v"},
            { 1117, "3u"},
            { 1118, "3t"},
            { 1119, "3s"},
            { 1120, "3r"},
            { 1121, "44"},
            { 1122, "43"},
            { 1123, "42"},
            { 1124, "41"},
            { 1125, "40"},
            { 1126, "49"},
            { 1127, "48"},
            { 1128, "47"},
            { 1129, "46"},
            { 1130, "45"},
            { 1131, "4e"},
            { 1132, "4d"},
            { 1133, "4c"},
            { 1134, "4b"},
            { 1135, "4a"},
            { 1136, "4j"},
            { 1137, "4i"},
            { 1138, "4h"},
            { 1139, "4g"},
            { 1140, "4f"},
            { 1141, "4o"},
            { 1142, "4n"},
            { 1143, "4m"},
            { 1144, "4l"},
            { 1145, "4k"},
            { 1146, "4t"},
            { 1147, "4s"},
            { 1148, "4r"},
            { 1149, "4q"},
            { 1150, "4p"},
            { 1151, "52"},
            { 1152, "51"},
            { 1153, "50"},
            { 1154, "4v"},
            { 1155, "4u"},
            { 1156, "57"},
            { 1157, "56"},
            { 1158, "55"},
            { 1159, "54"},
            { 1160, "53"},
            { 1161, "5c"},
            { 1162, "5b"},
            { 1163, "5a"},
            { 1164, "59"},
            { 1165, "58"},
            { 1166, "5h"},
            { 1167, "5g"},
            { 1168, "5f"},
            { 1169, "5e"},
            { 1170, "5d"},
            { 1171, "5m"},
            { 1172, "5l"},
            { 1173, "5k"},
            { 1174, "5j"},
            { 1175, "5i"},
            { 1176, "5r"},
            { 1177, "5q"},
            { 1178, "5p"},
            { 1179, "5o"},
            { 1180, "5n"},
            { 1181, "60"},
            { 1182, "5v"},
            { 1183, "5u"},
            { 1184, "5t"},
            { 1185, "5s"},
            { 1186, "65"},
            { 1187, "64"},
            { 1188, "63"},
            { 1189, "62"},
            { 1190, "61"},
            { 1191, "00"},
            { 1192, "01"},
            { 1193, "02"},
            { 1194, "03"},
            { 1195, "04"},
            { 1196, "05"},
            { 1197, "06"},
            { 1198, "07"},
            { 1199, "f1"},
            { 1200, "f2"},
            { 1201, "f3"},
            { 1202, "f4"},
            { 1203, "f5"},
            { 1204, "f6"},
            { 1205, "f7"},
            { 1206, "f8"},
            { 1207, "6u"},
            { 1208, "6t"},
            { 1209, "6s"},
            { 1210, "6r"},
            { 1211, "6q"},
            { 1212, "73"},
            { 1213, "72"},
            { 1214, "71"},
            { 1215, "70"},
            { 1216, "6v"},
            { 1217, "78"},
            { 1218, "77"},
            { 1219, "76"},
            { 1220, "75"},
            { 1221, "74"},
            { 1222, "7d"},
            { 1223, "7c"},
            { 1224, "7b"},
            { 1225, "7a"},
            { 1226, "79"},
            { 1227, "0d"},
            { 1228, "0c"},
            { 1229, "0b"},
            { 1230, "0a"},
            { 1231, "09"},
            { 1232, "0i"},
            { 1233, "0h"},
            { 1234, "0g"},
            { 1235, "0f"},
            { 1236, "0e"},
            { 1237, "0n"},
            { 1238, "0m"},
            { 1239, "0l"},
            { 1240, "0k"},
            { 1241, "0j"},
            { 1242, "2h"},
            { 1243, "2g"},
            { 1244, "2f"},
            { 1245, "2i"},
            { 1246, "2n"},
            { 1247, "2s"},
            { 1248, "31"},
            { 1249, "36"},
            { 1250, "3b"},
            { 1251, "3g"},
            { 1252, "3l"},
            { 1253, "3q"},
            { 1254, "2m"},
            { 1255, "2r"},
            { 1256, "30"},
            { 1257, "35"},
            { 1258, "3a"},
            { 1259, "3f"},
            { 1260, "3k"},
            { 1261, "3p"},
            { 1262, "2l"},
            { 1263, "2q"},
            { 1264, "2v"},
            { 1265, "34"},
            { 1266, "39"},
            { 1267, "3e"},
            { 1268, "3j"},
            { 1269, "3o"},
            { 1270, "2k"},
            { 1271, "2p"},
            { 1272, "2u"},
            { 1273, "33"},
            { 1274, "38"},
            { 1275, "3d"},
            { 1276, "3i"},
            { 1277, "3n"},
            { 1278, "2j"},
            { 1279, "2o"},
            { 1280, "2t"},
            { 1281, "32"},
            { 1282, "37"},
            { 1283, "3c"},
            { 1284, "3h"},
            { 1285, "3m"},
            { 1286, "1k"},
            { 1287, "1p"},
            { 1288, "1u"},
            { 1289, "23"},
            { 1290, "1j"},
            { 1291, "1o"},
            { 1292, "1t"},
            { 1293, "22"},
            { 1294, "1i"},
            { 1295, "1n"},
            { 1296, "1s"},
            { 1297, "21"},
            { 1298, "1h"},
            { 1299, "1m"},
            { 1300, "1r"},
            { 1301, "20"},
            { 1302, "1g"},
            { 1303, "1l"},
            { 1304, "1q"},
            { 1305, "1v"},
            { 1306, "6a"},
            { 1307, "6f"},
            { 1308, "6k"},
            { 1309, "6p"},
            { 1310, "69"},
            { 1311, "6e"},
            { 1312, "6j"},
            { 1313, "6o"},
            { 1314, "68"},
            { 1315, "6d"},
            { 1316, "6i"},
            { 1317, "6n"},
            { 1318, "67"},
            { 1319, "6c"},
            { 1320, "6h"},
            { 1321, "6m"},
            { 1322, "66"},
            { 1323, "6b"},
            { 1324, "6g"},
            { 1325, "6l"},
            { 1326, "2d"},
            { 1327, "2f"},
            { 1328, "0c"},
            { 1329, "0h"},
            { 1330, "0m"},
            { 1331, "0r"},
            { 1332, "10"},
            { 1333, "15"},
            { 1334, "1a"},
            { 1335, "1f"},
            { 1336, "0b"},
            { 1337, "0g"},
            { 1338, "0l"},
            { 1339, "0q"},
            { 1340, "0v"},
            { 1341, "14"},
            { 1342, "19"},
            { 1343, "1e"},
            { 1344, "0a"},
            { 1345, "0f"},
            { 1346, "0k"},
            { 1347, "0p"},
            { 1348, "0u"},
            { 1349, "13"},
            { 1350, "18"},
            { 1351, "1d"},
            { 1352, "09"},
            { 1353, "0e"},
            { 1354, "0j"},
            { 1355, "0o"},
            { 1356, "0t"},
            { 1357, "12"},
            { 1358, "17"},
            { 1359, "1c"},
            { 1360, "08"},
            { 1361, "0d"},
            { 1362, "0i"},
            { 1363, "0n"},
            { 1364, "0s"},
            { 1365, "11"},
            { 1366, "16"},
            { 1367, "1b"},
            { 1368, "08"},
            { 1369, "07"},
            { 1370, "06"},
            { 1371, "05"},
            { 1372, "04"},
            { 1373, "26"},
            { 1374, "25"},
            { 1375, "28"},
            { 1376, "27"},
            { 1377, "2a"},
            { 1378, "29"},
            { 1379, "2c"},
            { 1380, "2b"},
            { 1381, "2e"},
            { 1382, "2d"},
            { 1383, "1o"},
            { 1384, "b5"},
            { 1385, "b6"},
            { 1386, "b7"},
            { 1387, "b8"},
            { 1388, "b9"},
            { 1389, "bf"},
            { 1390, "bg"},
            { 1391, "bh"},
            { 1392, "bi"},
            { 1393, "bj"},
            { 1394, "C1"},
            { 1395, "C2"},
            { 1396, "C3"},
            { 1397, "C4"},
            { 1398, "C5"},
            { 1399, "C6"},
            { 1400, "C7"},
            { 1401, "C8"},
            { 1402, "C9"},
            { 1403, "C0"},
            { 1404, "Ca"},
            { 1405, "Cb"},
            { 1406, "Cc"},
            { 1407, "Cd"},
            { 1408, "Ce"},
            { 1409, "Cf"},
            { 1410, "Cg"},
            { 1411, "Ch"},
            { 1412, "Ci"},
            { 1413, "Cj"},
            { 1414, "F0"},
            { 1415, "F1"},
            { 1416, "F2"},
            { 1417, "F3"},
            { 1418, "F4"},
            { 1419, "F5"},
            { 1420, "F6"},
            { 1421, "F7"},
            { 1422, "F8"},
            { 1423, "F9"},
            { 1424, "Fa"},
            { 1425, "Fb"},
            { 1426, "Fc"},
            { 1427, "Fd"},
            { 1428, "Fe"},
            { 1429, "Ff"},
            { 1430, "Fg"},
            { 1431, "Fh"},
            { 1432, "Fi"},
            { 1433, "Fj"},
            { 1434, "P0"},
            { 1435, "P1"},
            { 1436, "P2"},
            { 1437, "P3"},
            { 1438, "P4"},
            { 1439, "P5"},
            { 1440, "P6"},
            { 1441, "P7"},
            { 1442, "P8"},
            { 1443, "P9"},
            { 1444, "Pa"},
            { 1445, "Pb"},
            { 1446, "Pc"},
            { 1447, "Pd"},
            { 1448, "Pe"},
            { 1449, "Pf"},
            { 1450, "Pg"},
            { 1451, "Ph"},
            { 1452, "Pi"},
            { 1453, "Pj"},
            { 1454, "1u"},
            { 1455, "1v"},
            { 1456, "ba"},
            { 1457, "bb"},
            { 1458, "bc"},
            { 1459, "bd"},
            { 1460, "be"},
            { 1461, "bu"},
            { 1462, "bv"},
            { 1463, "bw"},
            { 1464, "bx"},
            { 1465, "by"},
            { 1466, "bz"},
            { 1467, "bA"},
            { 1468, "bB"},
            { 1469, "bC"},
            { 1470, "bD"},
            { 1471, "bJ"},
            { 1472, "bK"},
            { 1473, "bL"},
            { 1474, "bM"},
            { 1475, "bN"},
            { 1476, "b0"},
            { 1477, "cy"},
            { 1478, "pa"},
            { 1479, "ml"},
            { 1480, "Ph"},
            { 1481, "e0"},
            { 1482, "Ap"},
            { 1483, "PL"},
            { 1484, "ih"},
            { 1485, "p6"},
            { 1486, "p5"},
            { 1487, "p4"},
            { 1488, "p3"},
            { 1489, "p2"},
            { 1490, "p1"},
            { 1491, "p0"},
            { 1492, "p7"},
            { 1493, "BR"},
            { 1494, "BS"},
            { 1495, "BT"},
            { 1496, "BU"},
            { 1497, "BV"},
            { 1498, "BW"},
            { 1499, "BX"},
            { 1500, "BY"},
            { 1501, "BZ"},
            { 1502, "c0"},
            { 1503, "c1"},
            { 1504, "c2"},
            { 1505, "c3"},
            { 1506, "c4"},
            { 1507, "c5"},
            { 1508, "c6"},
            { 1509, "c7"},
            { 1510, "c8"},
            { 1511, "c9"},
            { 1512, "ca"},
            { 1513, "cb"},
            { 1514, "cc"},
            { 1515, "cd"},
            { 1516, "ce"},
            { 1517, "cf"},
            { 1518, "cg"},
            { 1519, "ch"},
            { 1520, "ci"},
            { 1521, "cj"},
            { 1522, "ck"},
            { 1524, "v1"},
            { 1525, "v2"},
            { 1526, "v3"},
            { 1527, "v4"},
            { 1528, "v5"},
            { 1529, "v6"},
            { 1530, "B6"},
            { 1531, "B5"},
            { 1532, "B4"},
            { 1533, "B3"},
            { 1534, "B2"},
            { 1535, "B1"},
            { 1536, "B0"},
            { 1537, "B7"},
            { 1539, "7q"},
            { 1540, "0w"},
            { 1541, "7k"},
            { 1542, "7n"},
            { 1543, "7l"},
            { 1544, "0x"},
            { 1545, "7r"},
            { 1546, "7o"},
            { 1547, "u0"},
            { 1548, "tz"},
            { 1549, "7s"},
            { 1550, "7t"},
            { 1551, "1x"},
            { 1552, "1y"},
            { 1553, "1w"},
            { 1554, "cl"},
            { 1555, "cm"},
            { 1556, "cn"},
            { 1557, "co"},
            { 1558, "cp"},
            { 1559, "1z"},
            { 1560, "fh"},
            { 1561, "fm"},
            { 1562, "fr"},
            { 1563, "ma"},
            { 1564, "mb"},
            { 1565, "mc"},
            { 1566, "md"},
            { 1567, "me"},
            { 1568, "mf"},
            { 1569, "mg"},
            { 1570, "mh"},
            { 1571, "mi"},
            { 1572, "mj"},
            { 1573, "mk"},
            { 1574, "ml"},
            { 1575, "mm"},
            { 1576, "mn"},
        };
        public static string FromEDDBID(long eddbid)
        {
            string CoriolisID;
            if (!CoriolisIDs.TryGetValue(eddbid, out CoriolisID))
            {
                Logging.Error("Missing Coriolis ID for EDDB ID " + eddbid);
                CoriolisID = "-";
            }
            return CoriolisID;
        }
    }
}

