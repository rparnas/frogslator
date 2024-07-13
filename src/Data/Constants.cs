﻿namespace Frogslator;

internal static class Constants
{
  public static class Blocks
  {
    public static readonly Block GameboyHeader      = new Block(0x00100, 0x00150);
    public static readonly Block DialogAddressTable = new Block(0x1CB2E, 0x1DD68);
    public static readonly Block TitleGraphics      = new Block(0x4D770, 0x4DD10);
    public static readonly Block FontGraphics       = new Block(0x50000, 0x52000);
    public static readonly Block Dialog             = new Block(0x70000, 0x80000);

    public static readonly Block Dialog0 = new Block(0x70000, 0x74000);
    public static readonly Block Dialog1 = new Block(0x74000, 0x78000);
    public static readonly Block Dialog2 = new Block(0x78000, 0x7C000);
    public static readonly Block Dialog3 = new Block(0x7C000, 0x80000);
  }

  public static Dictionary<int, string> Comments = new Dictionary<int, string>
  {
    { 0x70000, ""},
    { 0x70018, ""},
    { 0x70033, ""},
    { 0x7004e, ""},
    { 0x7005e, ""},
    { 0x7006f, ""},
    { 0x7007a, ""},
    { 0x70098, ""},
    { 0x700a8, ""},
    { 0x700b4, ""},
    { 0x700c0, ""},
    { 0x700ca, ""},
    { 0x700f0, ""},
    { 0x7014d, ""},
    { 0x70171, ""},
    { 0x70196, ""},
    { 0x701a6, ""},
    { 0x701c2, ""},
    { 0x701cc, ""},
    { 0x701d5, ""},
    { 0x701df, ""},
    { 0x701e9, ""},
    { 0x701f3, ""},
    { 0x70210, ""},
    { 0x70219, ""},
    { 0x7022c, ""},
    { 0x70234, ""},
    { 0x7023e, ""},
    { 0x7026a, ""},
    { 0x7027a, ""},
    { 0x70290, ""},
    { 0x702c7, ""},
    { 0x702ee, ""},
    { 0x702f9, ""},
    { 0x7036c, ""},
    { 0x703c4, ""},
    { 0x703fd, ""},
    { 0x7041a, ""},
    { 0x70426, ""},
    { 0x70452, ""},
    { 0x7045c, ""},
    { 0x70475, ""},
    { 0x70488, ""},
    { 0x7050d, ""},
    { 0x70582, ""},
    { 0x70590, ""},
    { 0x705e2, ""},
    { 0x70605, ""},
    { 0x7061f, ""},
    { 0x70655, ""},
    { 0x706ae, ""},
    { 0x706e0, ""},
    { 0x70704, ""},
    { 0x70728, ""},
    { 0x7074f, ""},
    { 0x7075e, ""},
    { 0x7076a, ""},
    { 0x70789, ""},
    { 0x707eb, ""},
    { 0x70860, ""},
    { 0x7087b, ""},
    { 0x708a0, ""},
    { 0x708c1, ""},
    { 0x708d8, ""},
    { 0x708ed, ""},
    { 0x70953, ""},
    { 0x70966, ""},
    { 0x70975, ""},
    { 0x709b8, ""},
    { 0x709d5, ""},
    { 0x709e9, ""},
    { 0x709f9, ""},
    { 0x70a19, ""},
    { 0x70a53, ""},
    { 0x70a72, ""},
    { 0x70a94, ""},
    { 0x70aa9, ""},
    { 0x70ac7, ""},
    { 0x70aec, ""},
    { 0x70b20, ""},
    { 0x70b48, ""},
    { 0x70b7e, ""},
    { 0x70b8b, ""},
    { 0x70b99, ""},
    { 0x70bbb, ""},
    { 0x70be5, ""},
    { 0x70bf4, ""},
    { 0x70c1a, ""},
    { 0x70c3f, ""},
    { 0x70c53, ""},
    { 0x70c67, ""},
    { 0x70c82, ""},
    { 0x70ce7, ""},
    { 0x70d08, ""},
    { 0x70d2e, ""},
    { 0x70d50, ""},
    { 0x70d77, ""},
    { 0x70de0, ""},
    { 0x70e04, ""},
    { 0x70e30, ""},
    { 0x70e53, ""},
    { 0x70e6b, ""},
    { 0x70e84, ""},
    { 0x70e9d, ""},
    { 0x70eb1, ""},
    { 0x70ec6, ""},
    { 0x70eec, ""},
    { 0x70f06, ""},
    { 0x70f1c, ""},
    { 0x70f35, ""},
    { 0x70f56, ""},
    { 0x70f76, ""},
    { 0x70f9b, "Diary (1)"  },
    { 0x7102c, "Diary (2)"  },
    { 0x710c5, "Diary (3)"  },
    { 0x71154, "Diary (4)"  },
    { 0x711e7, "Diary (5)"  },
    { 0x71276, "Diary (6)"  },
    { 0x71301, "Diary (7)"  },
    { 0x7138c, "Diary (8)"  },
    { 0x71413, "Diary (9)"  },
    { 0x714a8, "Diary (10)" },
    { 0x71537, "Diary (11)" },
    { 0x715c0, "Diary (12)" },
    { 0x71653, "Diary (13)" },
    { 0x716d9, "Diary (14)" },
    { 0x71768, "Diary (15)" },
    { 0x717fb, "Diary (16)" },
    { 0x7188e, "Diary (17)" },
    { 0x7191b, "Diary (18)" },
    { 0x719aa, "Diary (19)" },
    { 0x71a3d, "Diary (20)" },
    { 0x71ace, "Diary (21)" },
    { 0x71b5f, "Diary (22)" },
    { 0x71be8, "Diary (23)" },
    { 0x71c73, "Diary (24)" },
    { 0x71d08, "Diary (25)" },
    { 0x71d9d, "Diary (26)" },
    { 0x71e2a, "Diary (27)" },
    { 0x71ebf, "Diary (28)" },
    { 0x71f48, "Diary (29)" },
    { 0x71fcf, "Diary (30)" },
    { 0x7205e, "Diary (31)" },
    { 0x720e9, "Diary (32)" },
    { 0x7217a, "Diary (33)" },
    { 0x72207, ""},
    { 0x7220f, ""},
    { 0x7221b, ""},
    { 0x72239, ""},
    { 0x7224f, ""},
    { 0x72261, ""},
    { 0x72278, ""},
    { 0x7228d, ""},
    { 0x722a0, ""},
    { 0x722b2, ""},
    { 0x722c5, ""},
    { 0x722d9, ""},
    { 0x722fc, ""},
    { 0x72314, ""},
    { 0x7232e, ""},
    { 0x7234c, ""},
    { 0x72385, ""},
    { 0x723cb, ""},
    { 0x723ea, ""},
    { 0x7240d, ""},
    { 0x72438, ""},
    { 0x72459, ""},
    { 0x72476, ""},
    { 0x72492, ""},
    { 0x724bb, ""},
    { 0x724e0, ""},
    { 0x7251f, ""},
    { 0x7253a, ""},
    { 0x7255a, ""},
    { 0x7257f, ""},
    { 0x7259e, ""},
    { 0x725bf, ""},
    { 0x725e0, ""},
    { 0x72603, ""},
    { 0x72623, ""},
    { 0x7264a, ""},
    { 0x72658, ""},
    { 0x72683, ""},
    { 0x726ac, ""},
    { 0x726ce, ""},
    { 0x726fa, ""},
    { 0x72724, ""},
    { 0x7274c, "Unused" },
    { 0x72758, "Unused" },
    { 0x72764, "Unused" },
    { 0x72770, "Unused" },
    { 0x7277c, "Unused" },
    { 0x72788, "Unused" },
    { 0x72794, "Unused" },
    { 0x727a0, ""},
    { 0x727cc, ""},
    { 0x727f4, ""},
    { 0x72821, ""},
    { 0x72846, ""},
    { 0x7285a, ""},
    { 0x7286d, ""},
    { 0x72893, ""},
    { 0x728b7, ""},
    { 0x728db, ""},
    { 0x728ff, ""},
    { 0x72923, ""},
    { 0x72947, ""},
    { 0x7296b, ""},
    { 0x72991, ""},
    { 0x729b7, ""},
    { 0x729dd, ""},
    { 0x72a06, ""},
    { 0x72a22, ""},
    { 0x72a4b, ""},
    { 0x72a61, ""},
    { 0x72a76, ""},
    { 0x72a8b, ""},
    { 0x72aa3, ""},
    { 0x72abc, ""},
    { 0x72ad3, ""},
    { 0x72aeb, ""},
    { 0x72afe, ""},
    { 0x72b12, ""},
    { 0x72b26, ""},
    { 0x72b3c, ""},
    { 0x72b6b, ""},
    { 0x72b90, ""},
    { 0x72bb2, ""},
    { 0x72c00, ""},
    { 0x72c15, ""},
    { 0x72c40, ""},
    { 0x72c62, ""},
    { 0x72c7c, ""},
    { 0x72d09, ""},
    { 0x72d21, ""},
    { 0x72daf, ""},
    { 0x72dcf, ""},
    { 0x72e0a, ""},
    { 0x72e5e, ""},
    { 0x72efd, ""},
    { 0x72f10, ""},
    { 0x72f26, ""},
    { 0x72f3b, ""},
    { 0x72f55, ""},
    { 0x72f7e, ""},
    { 0x72f9f, ""},
    { 0x72fd2, ""},
    { 0x72ff3, ""},
    { 0x73016, ""},
    { 0x7303d, ""},
    { 0x7305a, ""},
    { 0x73095, ""},
    { 0x730bd, ""},
    { 0x730c8, ""},
    { 0x73104, ""},
    { 0x73114, ""},
    { 0x73135, ""},
    { 0x7319e, ""},
    { 0x73227, ""},
    { 0x73291, ""},
    { 0x732b9, ""},
    { 0x732c3, ""},
    { 0x732e6, ""},
    { 0x7330b, ""},
    { 0x73319, ""},
    { 0x73344, ""},
    { 0x73352, ""},
    { 0x73372, ""},
    { 0x733b4, ""},
    { 0x733c7, ""},
    { 0x733ea, ""},
    { 0x73413, ""},
    { 0x7342b, ""},
    { 0x7346a, ""},
    { 0x73481, ""},
    { 0x7352e, ""},
    { 0x7354f, ""},
    { 0x73594, ""},
    { 0x735b5, ""},
    { 0x735f4, ""},
    { 0x7361a, ""},
    { 0x7363e, ""},
    { 0x7366c, ""},
    { 0x7369d, ""},
    { 0x736b4, ""},
    { 0x736c4, ""},
    { 0x736f6, ""},
    { 0x73724, ""},
    { 0x73734, ""},
    { 0x73759, ""},
    { 0x7376e, ""},
    { 0x7377d, ""},
    { 0x7379d, ""},
    { 0x737d9, ""},
    { 0x7381c, ""},
    { 0x73843, ""},
    { 0x7388f, ""},
    { 0x738a0, ""},
    { 0x738b9, ""},
    { 0x738d6, ""},
    { 0x73908, ""},
    { 0x73951, ""},
    { 0x7397e, ""},
    { 0x739a6, ""},
    { 0x739be, ""},
    { 0x73a31, ""},
    { 0x73a52, ""},
    { 0x73a9e, ""},
    { 0x73ada, ""},
    { 0x73b31, ""},
    { 0x73b5d, ""},
    { 0x73b78, ""},
    { 0x73bb1, ""},
    { 0x73bef, ""},
    { 0x73c33, ""},
    { 0x73c3b, ""},
    { 0x73c4b, ""},
    { 0x73c73, ""},
    { 0x73cbe, ""},
    { 0x73cde, ""},
    { 0x73d03, ""},
    { 0x73d23, ""},
    { 0x73dab, ""},
    { 0x73dfd, ""},
    { 0x73e7a, ""},
    { 0x73e9e, ""},
    { 0x73efe, ""},
    { 0x73f37, ""},
    { 0x73fb8, ""},
    { 0x74000, ""},
    { 0x74037, ""},
    { 0x7405c, ""},
    { 0x74072, ""},
    { 0x740ab, ""},
    { 0x740bb, ""},
    { 0x740cd, ""},
    { 0x740f7, ""},
    { 0x74119, ""},
    { 0x74123, ""},
    { 0x7413b, ""},
    { 0x7415c, ""},
    { 0x74179, ""},
    { 0x741a1, ""},
    { 0x741c7, ""},
    { 0x741d9, ""},
    { 0x74254, ""},
    { 0x74270, ""},
    { 0x74297, ""},
    { 0x742bc, ""},
    { 0x742d1, ""},
    { 0x74301, ""},
    { 0x74352, ""},
    { 0x74375, ""},
    { 0x743dc, ""},
    { 0x743ee, ""},
    { 0x74414, ""},
    { 0x74440, ""},
    { 0x744ad, ""},
    { 0x744c6, ""},
    { 0x7450b, ""},
    { 0x74516, ""},
    { 0x7452a, ""},
    { 0x74556, ""},
    { 0x74579, ""},
    { 0x74623, ""},
    { 0x74668, ""},
    { 0x74681, ""},
    { 0x746a6, ""},
    { 0x746c8, ""},
    { 0x746ef, ""},
    { 0x74711, ""},
    { 0x74730, ""},
    { 0x74744, ""},
    { 0x74770, ""},
    { 0x747ab, ""},
    { 0x747d7, ""},
    { 0x747f6, ""},
    { 0x74830, ""},
    { 0x7488f, ""},
    { 0x7490d, ""},
    { 0x7495a, ""},
    { 0x74980, ""},
    { 0x74a00, ""},
    { 0x74a18, ""},
    { 0x74a38, ""},
    { 0x74a5b, ""},
    { 0x74a70, ""},
    { 0x74abd, ""},
    { 0x74af0, ""},
    { 0x74b24, ""},
    { 0x74b51, ""},
    { 0x74b94, ""},
    { 0x74bbc, ""},
    { 0x74bf7, ""},
    { 0x74c39, ""},
    { 0x74c58, ""},
    { 0x74c6d, ""},
    { 0x74c91, ""},
    { 0x74cb3, ""},
    { 0x74cd9, ""},
    { 0x74d00, ""},
    { 0x74d19, ""},
    { 0x74d3e, ""},
    { 0x74d5c, ""},
    { 0x74d7e, ""},
    { 0x74dfc, ""},
    { 0x74e29, ""},
    { 0x74e49, ""},
    { 0x74e89, ""},
    { 0x74ea4, ""},
    { 0x74eef, ""},
    { 0x74f21, ""},
    { 0x74f35, ""},
    { 0x74f45, ""},
    { 0x74f54, ""},
    { 0x74fa4, ""},
    { 0x74fc2, ""},
    { 0x75014, ""},
    { 0x75021, ""},
    { 0x7506e, ""},
    { 0x75087, ""},
    { 0x750fc, ""},
    { 0x75143, ""},
    { 0x75166, ""},
    { 0x75192, ""},
    { 0x751b3, ""},
    { 0x751f5, ""},
    { 0x75212, ""},
    { 0x7526e, ""},
    { 0x752c0, ""},
    { 0x752db, ""},
    { 0x7530e, ""},
    { 0x75322, ""},
    { 0x75336, ""},
    { 0x7533c, ""},
    { 0x753bd, ""},
    { 0x753df, ""},
    { 0x753fc, ""},
    { 0x7541a, ""},
    { 0x7543f, ""},
    { 0x75466, ""},
    { 0x754ad, ""},
    { 0x754b8, ""},
    { 0x754d7, ""},
    { 0x754fd, ""},
    { 0x75524, ""},
    { 0x7553a, ""},
    { 0x7554b, ""},
    { 0x75573, ""},
    { 0x75593, ""},
    { 0x755c0, ""},
    { 0x755d7, ""},
    { 0x755ef, ""},
    { 0x75611, ""},
    { 0x75654, ""},
    { 0x7567d, ""},
    { 0x7568b, ""},
    { 0x756a0, ""},
    { 0x756eb, ""},
    { 0x75717, ""},
    { 0x75736, ""},
    { 0x75759, ""},
    { 0x75806, ""},
    { 0x7582c, ""},
    { 0x75838, ""},
    { 0x7584f, ""},
    { 0x7586c, ""},
    { 0x75891, ""},
    { 0x758b7, ""},
    { 0x758d5, ""},
    { 0x75962, ""},
    { 0x759c1, ""},
    { 0x75a1a, ""},
    { 0x75a5a, ""},
    { 0x75a73, ""},
    { 0x75a8f, ""},
    { 0x75aae, ""},
    { 0x75ac5, ""},
    { 0x75b0d, ""},
    { 0x75b30, ""},
    { 0x75b74, ""},
    { 0x75c20, ""},
    { 0x75c43, ""},
    { 0x75c5e, ""},
    { 0x75ca0, ""},
    { 0x75ccd, ""},
    { 0x75cec, ""},
    { 0x75d2a, ""},
    { 0x75d47, ""},
    { 0x75d5f, ""},
    { 0x75d7d, ""},
    { 0x75d9b, ""},
    { 0x75dbf, ""},
    { 0x75ddb, ""},
    { 0x75df9, ""},
    { 0x75e32, ""},
    { 0x75e59, ""},
    { 0x75e7d, ""},
    { 0x75ede, ""},
    { 0x75f08, ""},
    { 0x75fdc, ""},
    { 0x7601d, ""},
    { 0x7603e, ""},
    { 0x76054, ""},
    { 0x76078, ""},
    { 0x76091, ""},
    { 0x760a5, ""},
    { 0x760c8, ""},
    { 0x760f4, ""},
    { 0x76109, ""},
    { 0x7611c, ""},
    { 0x76163, ""},
    { 0x76187, ""},
    { 0x761c4, ""},
    { 0x761e2, ""},
    { 0x76209, ""},
    { 0x7629b, ""},
    { 0x762bb, ""},
    { 0x762e0, ""},
    { 0x76305, ""},
    { 0x76321, ""},
    { 0x7633e, ""},
    { 0x76372, ""},
    { 0x763cf, ""},
    { 0x763e6, ""},
    { 0x76403, ""},
    { 0x76420, ""},
    { 0x76448, ""},
    { 0x7645b, ""},
    { 0x7646a, ""},
    { 0x7647f, ""},
    { 0x76490, ""},
    { 0x764a1, ""},
    { 0x764b3, ""},
    { 0x764d1, ""},
    { 0x764e7, ""},
    { 0x76543, ""},
    { 0x7659f, ""},
    { 0x765ff, ""},
    { 0x76623, ""},
    { 0x76646, ""},
    { 0x76670, ""},
    { 0x76692, ""},
    { 0x766b6, ""},
    { 0x7671a, ""},
    { 0x76745, ""},
    { 0x767d4, ""},
    { 0x76819, ""},
    { 0x76829, ""},
    { 0x7685e, ""},
    { 0x7689d, ""},
    { 0x768c9, ""},
    { 0x768e7, ""},
    { 0x768ed, ""},
    { 0x768f3, ""},
    { 0x7690e, ""},
    { 0x7697f, ""},
    { 0x769ae, ""},
    { 0x769c3, ""},
    { 0x769eb, ""},
    { 0x76a39, ""},
    { 0x76a60, ""},
    { 0x76a77, ""},
    { 0x76a90, ""},
    { 0x76aad, ""},
    { 0x76aeb, ""},
    { 0x76b62, ""},
    { 0x76b7a, ""},
    { 0x76bb5, ""},
    { 0x76c16, ""},
    { 0x76c63, ""},
    { 0x76c8f, ""},
    { 0x76cf8, ""},
    { 0x76d2b, ""},
    { 0x76d98, ""},
    { 0x76dfc, ""},
    { 0x76e4c, ""},
    { 0x76e67, ""},
    { 0x76ea0, ""},
    { 0x76ec0, ""},
    { 0x76efc, ""},
    { 0x76f2a, ""},
    { 0x76f45, ""},
    { 0x76f86, ""},
    { 0x76fba, ""},
    { 0x76fca, ""},
    { 0x77012, ""},
    { 0x77035, ""},
    { 0x77176, ""},
    { 0x771cf, ""},
    { 0x771fa, ""},
    { 0x7721f, ""},
    { 0x77247, ""},
    { 0x7728a, ""},
    { 0x772ae, ""},
    { 0x772c9, ""},
    { 0x772dd, ""},
    { 0x773a7, ""},
    { 0x773dc, ""},
    { 0x773f6, ""},
    { 0x77406, ""},
    { 0x77426, ""},
    { 0x7743b, ""},
    { 0x77474, ""},
    { 0x774f2, ""},
    { 0x77533, ""},
    { 0x77554, ""},
    { 0x77563, ""},
    { 0x775a7, ""},
    { 0x7760b, ""},
    { 0x7761c, ""},
    { 0x77661, ""},
    { 0x77689, ""},
    { 0x776af, ""},
    { 0x776d7, ""},
    { 0x776f5, ""},
    { 0x77702, ""},
    { 0x777f5, ""},
    { 0x77800, ""},
    { 0x778ba, ""},
    { 0x779b3, ""},
    { 0x779da, ""},
    { 0x779fb, ""},
    { 0x77a1c, ""},
    { 0x77a3b, ""},
    { 0x77a61, ""},
    { 0x77a88, ""},
    { 0x77aac, ""},
    { 0x77ad1, ""},
    { 0x77ae5, ""},
    { 0x77b09, ""},
    { 0x77b31, ""},
    { 0x77b5b, ""},
    { 0x77b73, ""},
    { 0x77b87, ""},
    { 0x77ba9, ""},
    { 0x77bf1, ""},
    { 0x77c48, ""},
    { 0x77c82, ""},
    { 0x77caa, ""},
    { 0x77cd0, ""},
    { 0x77cfd, ""},
    { 0x77d1b, ""},
    { 0x77d43, ""},
    { 0x77d61, ""},
    { 0x77d79, ""},
    { 0x77d95, ""},
    { 0x77d9e, ""},
    { 0x77dba, ""},
    { 0x77dc7, ""},
    { 0x77ddb, ""},
    { 0x77deb, ""},
    { 0x77e09, ""},
    { 0x77e62, ""},
    { 0x77e88, ""},
    { 0x77f0c, ""},
    { 0x77f26, ""},
    { 0x77f4e, ""},
    { 0x77f72, ""},
    { 0x77f81, ""},
    { 0x77f9e, ""},
    { 0x77fc6, ""},
    { 0x78000, ""},
    { 0x78038, ""},
    { 0x7805b, ""},
    { 0x7807f, ""},
    { 0x780b0, ""},
    { 0x780d3, ""},
    { 0x78108, ""},
    { 0x78119, ""},
    { 0x7813b, ""},
    { 0x78172, ""},
    { 0x78192, ""},
    { 0x781a5, ""},
    { 0x781b5, ""},
    { 0x781c5, ""},
    { 0x781de, ""},
    { 0x78202, ""},
    { 0x7822b, ""},
    { 0x7824e, ""},
    { 0x78271, ""},
    { 0x78290, ""},
    { 0x782b8, ""},
    { 0x782d6, ""},
    { 0x782e2, ""},
    { 0x782fc, ""},
    { 0x78310, ""},
    { 0x7833e, ""},
    { 0x78370, ""},
    { 0x783a2, ""},
    { 0x783c0, ""},
    { 0x783da, ""},
    { 0x78429, ""},
    { 0x78437, ""},
    { 0x7844a, ""},
    { 0x78456, ""},
    { 0x78499, ""},
    { 0x784aa, ""},
    { 0x784b8, ""},
    { 0x784cc, ""},
    { 0x784da, ""},
    { 0x7851d, ""},
    { 0x7853c, ""},
    { 0x78576, ""},
    { 0x785ef, ""},
    { 0x7863d, ""},
    { 0x78692, ""},
    { 0x786bf, ""},
    { 0x786e3, ""},
    { 0x78734, ""},
    { 0x78757, ""},
    { 0x7878a, ""},
    { 0x787bd, ""},
    { 0x787d3, ""},
    { 0x78828, ""},
    { 0x7883c, ""},
    { 0x78863, ""},
    { 0x78887, ""},
    { 0x7889d, ""},
    { 0x788b8, ""},
    { 0x788d9, ""},
    { 0x78918, ""},
    { 0x78972, ""},
    { 0x78999, ""},
    { 0x789b3, ""},
    { 0x789d4, ""},
    { 0x78a1a, ""},
    { 0x78a53, ""},
    { 0x78a74, ""},
    { 0x78a8c, ""},
    { 0x78ab6, ""},
    { 0x78ad4, ""},
    { 0x78aec, ""},
    { 0x78af8, ""},
    { 0x78b2a, ""},
    { 0x78b75, ""},
    { 0x78ba8, ""},
    { 0x78bcc, ""},
    { 0x78be4, ""},
    { 0x78c10, ""},
    { 0x78c93, ""},
    { 0x78cc4, ""},
    { 0x78ce5, ""},
    { 0x78d03, ""},
    { 0x78d28, ""},
    { 0x78d37, ""},
    { 0x78d5f, ""},
    { 0x78d84, ""},
    { 0x78d90, ""},
    { 0x78d9f, ""},
    { 0x78dc4, ""},
    { 0x78dd9, ""},
    { 0x78ded, ""},
    { 0x78e14, ""},
    { 0x78e35, ""},
    { 0x78e5b, ""},
    { 0x78e7a, ""},
    { 0x78ee2, ""},
    { 0x78f12, ""},
    { 0x78f26, ""},
    { 0x78f4e, ""},
    { 0x78f6e, ""},
    { 0x790b2, ""},
    { 0x790d7, ""},
    { 0x79122, ""},
    { 0x79149, ""},
    { 0x791ae, ""},
    { 0x791b8, ""},
    { 0x79229, ""},
    { 0x792f9, ""},
    { 0x7931a, ""},
    { 0x79342, ""},
    { 0x79363, ""},
    { 0x793eb, ""},
    { 0x793fe, ""},
    { 0x7943c, ""},
    { 0x79455, ""},
    { 0x79478, ""},
    { 0x794a1, ""},
    { 0x794ab, ""},
    { 0x794b9, ""},
    { 0x794c7, ""},
    { 0x794d3, ""},
    { 0x794e4, ""},
    { 0x794f2, ""},
    { 0x79512, ""},
    { 0x79524, ""},
    { 0x79545, ""},
    { 0x79577, ""},
    { 0x79671, ""},
    { 0x7967f, ""},
    { 0x796b6, ""},
    { 0x796c9, ""},
    { 0x796e5, ""},
    { 0x79708, ""},
    { 0x7971a, ""},
    { 0x79739, ""},
    { 0x79753, ""},
    { 0x79763, ""},
    { 0x79785, ""},
    { 0x797aa, ""},
    { 0x79801, ""},
    { 0x79854, ""},
    { 0x79884, ""},
    { 0x798ba, ""},
    { 0x7992a, ""},
    { 0x79949, ""},
    { 0x79956, ""},
    { 0x7995f, ""},
    { 0x799bb, ""},
    { 0x799de, ""},
    { 0x799f7, ""},
    { 0x79a13, ""},
    { 0x79a58, ""},
    { 0x79a6d, ""},
    { 0x79a98, ""},
    { 0x79aaa, ""},
    { 0x79abc, ""},
    { 0x79acf, ""},
    { 0x79af7, ""},
    { 0x79b15, ""},
    { 0x79b2a, ""},
    { 0x79ba7, ""},
    { 0x79bcb, ""},
    { 0x79bd5, ""},
    { 0x79c03, ""},
    { 0x79c20, ""},
    { 0x79c44, ""},
    { 0x79cc3, ""},
    { 0x79d05, ""},
    { 0x79d54, ""},
    { 0x79d74, ""},
    { 0x79d98, ""},
    { 0x79dd1, ""},
    { 0x79de5, ""},
    { 0x79e04, ""},
    { 0x79e15, ""},
    { 0x79e28, ""},
    { 0x79e82, ""},
    { 0x79ebe, ""},
    { 0x79ee1, ""},
    { 0x79f14, ""},
    { 0x79f35, ""},
    { 0x79f76, ""},
    { 0x79f96, ""},
    { 0x79fab, ""},
    { 0x7a02c, ""},
    { 0x7a097, ""},
    { 0x7a0c1, ""},
    { 0x7a0ea, ""},
    { 0x7a13a, ""},
    { 0x7a188, ""},
    { 0x7a209, ""},
    { 0x7a236, ""},
    { 0x7a24a, ""},
    { 0x7a26d, ""},
    { 0x7a28a, ""},
    { 0x7a2b0, ""},
    { 0x7a2d7, ""},
    { 0x7a2fb, ""},
    { 0x7a31f, ""},
    { 0x7a342, ""},
    { 0x7a373, ""},
    { 0x7a3c4, ""},
    { 0x7a3e7, ""},
    { 0x7a42d, ""},
    { 0x7a448, ""},
    { 0x7a468, ""},
    { 0x7a488, ""},
    { 0x7a4a6, ""},
    { 0x7a542, ""},
    { 0x7a568, ""},
    { 0x7a593, ""},
    { 0x7a5b9, ""},
    { 0x7a5e8, ""},
    { 0x7a604, ""},
    { 0x7a641, ""},
    { 0x7a658, ""},
    { 0x7a66a, ""},
    { 0x7a690, ""},
    { 0x7a6b3, ""},
    { 0x7a6d3, ""},
    { 0x7a6f7, ""},
    { 0x7a746, ""},
    { 0x7a75f, ""},
    { 0x7a786, ""},
    { 0x7a7bd, ""},
    { 0x7a7cc, ""},
    { 0x7a7df, ""},
    { 0x7a7ef, ""},
    { 0x7a810, ""},
    { 0x7a856, ""},
    { 0x7a894, ""},
    { 0x7a8d0, ""},
    { 0x7a8f6, ""},
    { 0x7a922, ""},
    { 0x7a94a, ""},
    { 0x7a972, ""},
    { 0x7a9af, ""},
    { 0x7a9ed, ""},
    { 0x7aa09, ""},
    { 0x7aa37, ""},
    { 0x7aa58, ""},
    { 0x7aa7e, ""},
    { 0x7aa94, ""},
    { 0x7aab9, ""},
    { 0x7aacc, ""},
    { 0x7ab85, ""},
    { 0x7abaf, ""},
    { 0x7abde, ""},
    { 0x7ac07, ""},
    { 0x7ac29, ""},
    { 0x7ac65, ""},
    { 0x7aca0, ""},
    { 0x7acef, ""},
    { 0x7ad3c, ""},
    { 0x7ad6b, ""},
    { 0x7ad89, ""},
    { 0x7ada5, ""},
    { 0x7adf2, ""},
    { 0x7ae14, ""},
    { 0x7ae56, ""},
    { 0x7ae66, ""},
    { 0x7ae73, ""},
    { 0x7ae8a, ""},
    { 0x7ae9c, ""},
    { 0x7aec8, ""},
    { 0x7aeee, ""},
    { 0x7af13, ""},
    { 0x7af3c, ""},
    { 0x7afb2, ""},
    { 0x7b031, ""},
    { 0x7b049, ""},
    { 0x7b073, ""},
    { 0x7b098, ""},
    { 0x7b0bb, ""},
    { 0x7b0c7, ""},
    { 0x7b13e, ""},
    { 0x7b14f, ""},
    { 0x7b165, ""},
    { 0x7b1f2, ""},
    { 0x7b215, ""},
    { 0x7b227, ""},
    { 0x7b242, ""},
    { 0x7b26a, ""},
    { 0x7b28e, ""},
    { 0x7b2ac, ""},
    { 0x7b2ca, ""},
    { 0x7b2e5, ""},
    { 0x7b302, ""},
    { 0x7b35b, ""},
    { 0x7b369, ""},
    { 0x7b383, ""},
    { 0x7b3a5, ""},
    { 0x7b3bb, ""},
    { 0x7b3d4, ""},
    { 0x7b3ea, ""},
    { 0x7b452, ""},
    { 0x7b4c5, ""},
    { 0x7b524, ""},
    { 0x7b54e, ""},
    { 0x7b5cf, ""},
    { 0x7b5e5, ""},
    { 0x7b608, ""},
    { 0x7b61f, ""},
    { 0x7b679, ""},
    { 0x7b685, ""},
    { 0x7b6bd, ""},
    { 0x7b6cc, ""},
    { 0x7b6ec, ""},
    { 0x7b776, ""},
    { 0x7b797, ""},
    { 0x7b7b6, ""},
    { 0x7b7da, ""},
    { 0x7b80b, ""},
    { 0x7b842, ""},
    { 0x7b85f, ""},
    { 0x7b8d4, ""},
    { 0x7b8ef, ""},
    { 0x7ba5a, ""},
    { 0x7ba7b, ""},
    { 0x7ba9a, ""},
    { 0x7bb2b, ""},
    { 0x7bb4a, ""},
    { 0x7bb6c, ""},
    { 0x7bb7a, ""},
    { 0x7bb9d, ""},
    { 0x7bbbf, ""},
    { 0x7bbcd, ""},
    { 0x7bbff, ""},
    { 0x7bc20, ""},
    { 0x7bc38, ""},
    { 0x7bc5a, ""},
    { 0x7bc83, ""},
    { 0x7bca4, ""},
    { 0x7bcc1, ""},
    { 0x7bd30, ""},
    { 0x7bd9c, ""},
    { 0x7bdb3, ""},
    { 0x7bdd9, ""},
    { 0x7be2d, ""},
    { 0x7be53, ""},
    { 0x7bee0, ""},
    { 0x7bf06, ""},
    { 0x7bf27, ""},
    { 0x7bf2f, ""},
    { 0x7bf47, ""},
    { 0x7bf6b, ""},
    { 0x7bfb0, ""},
    { 0x7bfd1, ""},
    { 0x7bfde, ""},
    { 0x7c000, ""},
    { 0x7c01b, ""},
    { 0x7c034, ""},
    { 0x7c049, ""},
    { 0x7c060, ""},
    { 0x7c089, ""},
    { 0x7c0ab, ""},
    { 0x7c0be, ""},
    { 0x7c0cf, ""},
    { 0x7c0fa, ""},
    { 0x7c13b, ""},
    { 0x7c14f, ""},
    { 0x7c19b, ""},
    { 0x7c1bd, ""},
    { 0x7c1f4, ""},
    { 0x7c23f, ""},
    { 0x7c25d, ""},
    { 0x7c27d, ""},
    { 0x7c2a6, ""},
    { 0x7c2d8, ""},
    { 0x7c2fb, ""},
    { 0x7c32a, ""},
    { 0x7c338, ""},
    { 0x7c363, ""},
    { 0x7c38c, ""},
    { 0x7c3a7, ""},
    { 0x7c3cc, ""},
    { 0x7c414, ""},
    { 0x7c43a, ""},
    { 0x7c460, ""},
    { 0x7c46b, ""},
    { 0x7c48c, ""},
    { 0x7c4cf, ""},
    { 0x7c4f1, ""},
    { 0x7c501, ""},
    { 0x7c51c, ""},
    { 0x7c545, ""},
    { 0x7c566, ""},
    { 0x7c58f, ""},
    { 0x7c5c8, ""},
    { 0x7c5ff, ""},
    { 0x7c646, ""},
    { 0x7c664, ""},
    { 0x7c689, ""},
    { 0x7c699, ""},
    { 0x7c6be, ""},
    { 0x7c6d6, ""},
    { 0x7c6e4, ""},
    { 0x7c791, ""},
    { 0x7c7b2, ""},
    { 0x7c7d9, ""},
    { 0x7c7f2, ""},
    { 0x7c825, ""},
    { 0x7c844, ""},
    { 0x7c86a, ""},
    { 0x7c88c, ""},
    { 0x7c8af, ""},
    { 0x7c8d6, ""},
    { 0x7c905, ""},
    { 0x7c91a, ""},
    { 0x7c93e, ""},
    { 0x7c961, ""},
    { 0x7c97a, ""},
    { 0x7c99c, ""},
    { 0x7c9bd, ""},
    { 0x7c9de, ""},
    { 0x7c9eb, ""},
    { 0x7ca0a, ""},
    { 0x7ca25, ""},
    { 0x7ca41, ""},
    { 0x7ca5d, ""},
    { 0x7ca79, ""},
    { 0x7caa9, ""},
    { 0x7cac5, ""},
    { 0x7caef, ""},
    { 0x7cb02, ""},
    { 0x7cb28, ""},
    { 0x7cb54, ""},
    { 0x7cb7b, ""},
    { 0x7cb90, ""},
    { 0x7cb9c, ""},
    { 0x7cbc7, ""},
    { 0x7cbd4, ""},
    { 0x7cbfa, ""},
    { 0x7cc0f, ""},
    { 0x7cc2b, ""},
    { 0x7cc45, ""},
    { 0x7ccaf, ""},
    { 0x7cccd, ""},
    { 0x7cce4, ""},
    { 0x7ccfd, ""},
    { 0x7cd16, ""},
    { 0x7cd3a, ""},
    { 0x7cd5e, ""},
    { 0x7cd73, ""},
    { 0x7cd8b, ""},
    { 0x7cda9, ""},
    { 0x7ce67, ""},
    { 0x7ce8d, ""},
    { 0x7ceb8, ""},
    { 0x7cedc, ""},
    { 0x7cf1f, ""},
    { 0x7cf85, ""},
    { 0x7cf94, ""},
    { 0x7cff9, ""},
    { 0x7d00d, ""},
    { 0x7d021, ""},
    { 0x7d05b, ""},
    { 0x7d067, ""},
    { 0x7d074, ""},
    { 0x7d088, ""},
    { 0x7d0cb, ""},
    { 0x7d13d, ""},
    { 0x7d146, ""},
    { 0x7d154, ""},
    { 0x7d160, ""},
    { 0x7d16c, ""},
    { 0x7d175, ""},
    { 0x7d17f, ""},
    { 0x7d1d6, ""},
    { 0x7d201, ""},
    { 0x7d214, ""},
    { 0x7d22c, ""},
    { 0x7d236, ""},
    { 0x7d23f, ""},
    { 0x7d248, ""},
    { 0x7d251, ""},
    { 0x7d258, ""},
    { 0x7d287, ""},
    { 0x7d2c0, ""},
    { 0x7d2ea, ""},
    { 0x7d32a, ""},
    { 0x7d34e, ""},
    { 0x7d373, ""},
    { 0x7d3a1, ""},
    { 0x7d3ef, ""},
    { 0x7d413, ""},
    { 0x7d43e, ""},
    { 0x7d455, ""},
    { 0x7d491, ""},
    { 0x7d4af, ""},
    { 0x7d4e9, ""},
    { 0x7d557, ""},
    { 0x7d55d, ""},
    { 0x7d567, ""},
    { 0x7d571, ""},
    { 0x7d58d, ""},
    { 0x7d5c0, ""},
    { 0x7d5e8, ""},
    { 0x7d605, ""},
    { 0x7d62b, ""},
    { 0x7d639, ""},
    { 0x7d687, ""},
    { 0x7d6ac, ""},
    { 0x7d6df, ""},
    { 0x7d6fc, ""},
    { 0x7d74b, ""},
    { 0x7d77c, ""},
    { 0x7d79b, ""},
    { 0x7d7a8, ""},
    { 0x7d7b3, ""},
    { 0x7d7db, ""},
    { 0x7d855, ""},
    { 0x7d870, ""},
    { 0x7d8b8, ""},
    { 0x7d8d0, ""},
    { 0x7d8dc, ""},
    { 0x7d8eb, ""},
    { 0x7d90f, ""},
    { 0x7d945, ""},
    { 0x7d971, ""},
    { 0x7d97c, ""},
    { 0x7d98e, ""},
    { 0x7d99a, ""},
    { 0x7d9ae, ""},
    { 0x7d9e5, ""},
    { 0x7d9f9, ""},
    { 0x7da0e, ""},
    { 0x7da24, ""},
    { 0x7da6d, ""},
    { 0x7da7d, ""},
    { 0x7dabe, ""},
    { 0x7dae1, ""},
    { 0x7dafd, ""},
    { 0x7db1b, ""},
    { 0x7db2d, ""},
    { 0x7db38, ""},
    { 0x7db4f, ""},
    { 0x7db76, ""},
    { 0x7db86, ""},
    { 0x7dba7, ""},
    { 0x7dbb7, ""},
    { 0x7dc45, ""},
    { 0x7dc8e, ""},
    { 0x7dd23, ""},
    { 0x7dd50, ""},
    { 0x7dd92, ""},
    { 0x7ddab, ""},
    { 0x7ddd4, ""},
    { 0x7ddf6, ""},
    { 0x7de03, ""},
    { 0x7de12, ""},
    { 0x7de1e, ""},
    { 0x7de32, ""},
    { 0x7de48, ""},
    { 0x7de65, ""},
    { 0x7deaf, ""},
    { 0x7dec4, ""},
    { 0x7def1, ""},
    { 0x7df18, ""},
    { 0x7df34, ""},
    { 0x7df4e, ""},
    { 0x7df6e, ""},
    { 0x7df8a, ""},
    { 0x7dfaa, ""},
    { 0x7dfc5, ""},
    { 0x7e006, ""},
    { 0x7e051, ""},
    { 0x7e068, ""},
    { 0x7e08f, ""},
    { 0x7e099, ""},
    { 0x7e0a7, ""},
    { 0x7e0af, ""},
    { 0x7e0cf, ""},
    { 0x7e0f1, ""},
    { 0x7e120, ""},
    { 0x7e12e, ""},
    { 0x7e14b, ""},
    { 0x7e194, ""},
    { 0x7e1c4, ""},
    { 0x7e1e8, ""},
    { 0x7e20d, ""},
    { 0x7e22e, ""},
    { 0x7e250, ""},
    { 0x7e27e, ""},
    { 0x7e2bd, ""},
    { 0x7e2d8, ""},
    { 0x7e2ee, ""},
    { 0x7e309, ""},
    { 0x7e331, ""},
    { 0x7e347, ""},
    { 0x7e390, ""},
    { 0x7e3b6, ""},
    { 0x7e3da, ""},
    { 0x7e3fb, ""},
    { 0x7e41f, ""},
    { 0x7e443, ""},
    { 0x7e46a, ""},
    { 0x7e495, ""},
    { 0x7e4c1, ""},
    { 0x7e4ec, ""},
    { 0x7e4f5, ""},
    { 0x7e500, ""},
    { 0x7e526, ""},
    { 0x7e54e, ""},
    { 0x7e590, ""},
    { 0x7e5ea, ""},
    { 0x7e600, ""},
    { 0x7e720, ""},
    { 0x7e743, ""},
    { 0x7e763, ""},
    { 0x7e7b7, ""},
    { 0x7e7d1, ""},
    { 0x7e7ef, ""},
    { 0x7e815, ""},
    { 0x7e82e, ""},
    { 0x7e856, ""},
    { 0x7e873, ""},
    { 0x7e8ab, ""},
    { 0x7e8c0, ""},
    { 0x7e94e, ""},
    { 0x7e970, ""},
    { 0x7e992, ""},
    { 0x7e9b8, ""},
    { 0x7e9f7, ""},
    { 0x7ea16, ""},
    { 0x7ea59, ""},
    { 0x7ea8c, ""},
    { 0x7eab5, ""},
    { 0x7eacc, ""},
    { 0x7eaf6, ""},
    { 0x7eb19, ""},
    { 0x7eb2e, ""},
    { 0x7eb3d, ""},
    { 0x7ec28, ""},
    { 0x7ec46, ""},
    { 0x7eccb, ""},
    { 0x7ecf3, ""},
    { 0x7ed63, ""},
    { 0x7ed77, ""},
    { 0x7edd9, ""},
    { 0x7ee00, ""},
    { 0x7ee1d, ""},
    { 0x7ee26, ""},
    { 0x7ee4c, ""},
    { 0x7eeaa, ""},
    { 0x7eed8, ""},
    { 0x7eef4, ""},
    { 0x7ef24, ""},
    { 0x7ef4b, ""},
    { 0x7ef6b, ""},
    { 0x7ef83, ""},
    { 0x7efb2, ""},
    { 0x7efd7, ""},
    { 0x7efed, ""},
    { 0x7f036, ""},
    { 0x7f05c, ""},
    { 0x7f06b, ""},
    { 0x7f083, "News (1)"},
    { 0x7f0ac, "News (2)"},
    { 0x7f0dc, "News (3)"},
    { 0x7f107, "News (4)"},
    { 0x7f127, "News (5)"},
    { 0x7f14b, "News (6)"},
    { 0x7f171, "News (7)"},
    { 0x7f19d, "News (8)"},
    { 0x7f1c9, "News (9)"},
    { 0x7f1f1, "News (10)"},
    { 0x7f238, "News (11)"},
    { 0x7f2bc, "News (12)"},
    { 0x7f2e6, "News (13)"},
    { 0x7f311, "News (14)"},
    { 0x7f33a, "News (15)"},
    { 0x7f363, "News (16)"},
    { 0x7f391, "News (17)"},
    { 0x7f3bf, "News (18)"},
    { 0x7f40c, "News (19)"},
    { 0x7f43b, "News (20)"},
    { 0x7f465, "News (21)"},
    { 0x7f492, "News (22)"},
    { 0x7f4be, "News (23)"},
    { 0x7f535, "News (24)"},
    { 0x7f580, "News (25)"},
    { 0x7f5c3, "News (26)"},
    { 0x7f60b, "News (27)"},
    { 0x7f659, "News (28)"},
    { 0x7f69f, "News (29)"},
  };

  public static readonly HashSet<int> UnusedDialog = new HashSet<int>
  {
    0x7274C,
    0x72758,
    0x72764,
    0x72770,
    0x7277C,
    0x72788,
    0x72794,
  };
}
