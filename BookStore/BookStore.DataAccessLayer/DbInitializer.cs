using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.DataAccessLayer
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<BookStoreDbContext>
    {
        protected override void Seed(BookStoreDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            #region Add Categories

            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryName = "Literature & Fiction",
                    Description = "Literature & Fiction Books",
                },
                new Category()
                {
                    CategoryName = "Self Help",
                    Description = "Self Help Books Self Help Books"
                },
                new Category()
                {
                    CategoryName = "Manga, Comic",
                    Description = "Manga, Comic Books Manga, Comic Books"
                }
            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();

            #endregion

            #region Add Authors

            var authors = new List<Author>()
            {
                new Author()
                {
                    AuthorName = "J. K. Rowling",
                    Description = "Joanne \"Jo\" Rowling, sinh ngày 31 tháng 7 năm 1965, bút danh là J. K. Rowling, và Robert Galbraith. Cư ngụ tại thủ đô Edinburgh,Scotland là tiểu thuyết gia người Anh, tác giả bộ truyện giả tưởng nổi tiếng Harry Potter với bút danh J. K. Rowling.",
                },
                new Author()
                {
                    AuthorName = "Dale Carnegie",
                    Description = "Dale Breckenridge Carnegie(24 tháng 11 năm 1888 – 1 tháng 11 năm 1955) là một nhà văn và nhà thuyết trình Mỹ. Ra đời trong cảnh nghèo đói tại một trang trại ở Missouri, ông là tác giả cuốn Đắc Nhân Tâm, được xuất bản lần đầu năm 1936, một cuốn sách thuộc hàng bán chạy nhất và được biết đến nhiều nhất cho đến tận ngày nay.",
                },
                new Author()
                {
                    AuthorName = "Aoyama Gosho",
                    Description = "Aoyama Gōshō (青山 あおやま 剛昌 ごうしょう (Thanh Sơn Cương Xương)?), tên khai sinh là Aoyama Yoshimasa (青山 あおやま 剛昌 よしまさ (Thanh Sơn Cương Xương)? - giữ nguyên Kanji nhưng thay cách đọc), sinh ngày 21 tháng 6 năm 1963 tại Hokuei tỉnh Tottori, Nhật Bản (trước đây còn được biết tới là Daiei, tỉnh Tottori). Ông là một nhà sáng tác truyện tranh, được biết đến với bộ truyện tranh Thám tử lừng danh Conan.",
                },
                new Author()
                {
                    AuthorName = "Eiichiro Oda",
                    Description = "Oda Eiichiro (尾田 栄一郎 Oda Eiichirō?, Vĩ Điền Vinh Nhất Lang) (sinh ngày 1 tháng 1 năm 1975 tại thành phố Kumamoto, tỉnh Kumamoto) là một họa sĩ truyện tranh người Nhật Bản, hiện đang sáng tác cho nhà xuất bản Shūeisha. Tác phẩm tiêu biểu: One Piece.",
                },
                new Author()
                {
                    AuthorName = "Fujiko.F.Fujio",
                    Description = "Fujiko Fujio (藤子 不二雄, ふじこ ふじお) (Đằng Tử Bất Nhị Hùng) IPA: /ɸɯdʒiko ɸɯdʒio/ là bút danh chung của hai nghệ sĩ manga Nhật Bản. Năm 1987, họ chia tay để theo đuổi con đường sáng tác riêng rẽ và trở thành \"Fujiko F. Fujio\" và \"Fujiko Fujio (A)\". Trong số các tác phẩm của cả hai, tác phẩm được biết đến rộng rãi nhất là Doraemon.",
                }
            };
            authors.ForEach(s => context.Authors.Add(s));
            context.SaveChanges();

            #endregion

            #region Add Publishers

            var publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    PublisherName = "Nhà xuất bản Trẻ",
                    Description = "Dù chiếm một phần không nhỏ trong các đầu sách của nhà xuất bản Trẻ là sách kiến thức phổ thông, thường thức đời sống, mảng sách hư cấu (sách dịch lẫn sách trong nước) mới có những ấn phẩm để lại dấu ấn. Nhà xuất bản Trẻ cũng là bệ phóng cho những tên tuổi văn học Việt Nam đương đại như Nguyễn Nhật Ánh hay Nguyễn Ngọc Tư; hoặc giới thiệu nhiều tác giả nổi tiếng trên thế giới đến Việt Nam như Mario Puzo (Bố già), Paul Auster, Thomas Mann (qua Tủ sách Cánh cửa mở rộng), J. K. Rowling (qua bộ sách Harry Potter)...",
                },
                new Publisher()
                {
                    PublisherName = "Nhà xuất bản Kim Đồng",
                    Description = "Nhà xuất bản Kim Đồng là nhà xuất bản chuyên sản xuất và phát hành sách, văn hóa phẩm dành cho trẻ em lớn nhất tại Việt Nam với hơn 1.000 đầu sách mỗi năm thuộc nhiều thể loại như văn học, lịch sử, khoa học, truyện tranh,... Bên cạnh việc hợp tác với các cá nhân vá tổ chức trong nước, Nhà xuất bản Kim Đồng còn hợp tác với hơn 70 nhà xuất bản khác trên khắp thế giới, đặc biệt các nhà xuất bản như Dorling Kindersley, HarperCollins UK, Simon and Schuster UK, Dami International, Shogakukan, Nhà xuất bản Seoul,...",
                },
                new Publisher()
                {
                    PublisherName = "First News - Trí Việt",
                    Description = "First News là thương hiệu quốc tế của Công ty Văn hóa Sáng tạo Trí Việt, là một trong những thương hiệu xuất bản uy tín và được bạn đọc yêu thích nhất tại Việt Nam. Ra đời từ năm 1994, First News đã trải qua 20 năm kinh nghiệm trong lĩnh vực xuất bản sách, với trên 2.000 cuốn sách giá trị ra mắt bạn đọc trên tất cả các lĩnh vực khác nhau, trong đó có 90% các đầu sách được chuyển ngữ từ các tác giả nổi tiếng trên thế giới. Đây là một trong những đơn vị sớm nhất ký và tuân thủ Công ước Berne năm 2003.",
                }
            };
            publishers.ForEach(s => context.Publishers.Add(s));
            context.SaveChanges();

            #endregion

            #region Add Books
            var books = new List<Book>
            {
                new Book()
                {
                    Title = "How To Win Friends And Influence People",
                    Summary = "Tại sao Đắc Nhân Tâm luôn trong Top sách bán chạy nhất thế giới? Bởi vì đó là cuốn sách mọi người đều nên đọc. Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.",
                    ImageUrl = "book-0001.jpg",
                    Price = 169000M,
                    CreatedDate = new DateTimeOffset(2004,07,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2004,07,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 52,
                    Category = categories.Single(c=>c.CategoryName==("Self Help")),
                    Author = authors.Single(a=>a.AuthorName==("Dale Carnegie")),
                    Publisher = publishers.Single(p=>p.PublisherName==("First News - Trí Việt"))
                },
                new Book()
                {
                    Title = "How To Stop Worrying And Start Living",
                    Summary = "Quẳng Gánh Lo Đi Và Vui Sống là cuốn sách mà cái tên đã nói lên tất cả nội dung chuyển tải trên những trang giấy. Bất kỳ ai đang sống đều sẽ có những lo lắng thường trực về học hành, công việc, những hoá đơn, chuyện nhà cửa,... Cuộc sống không dễ dàng giải thoát bạn khỏi căng thẳng, ngược lại, nếu quá lo lắng, bạn có thể mắc bệnh trầm cảm. Quẳng Gánh Lo Đi Và Vui Sống khuyên bạn hãy khóa chặt dĩ vãng và tương lai lại để sống trong cái phòng kín mít của ngày hôm nay. Mọi vấn đề đều có thể được giải quyết, chỉ cần bạn bình tĩnh và xác định đúng hành động cần làm vào đúng thời điểm.",
                    ImageUrl = "book-0002.jpg",
                    Price = 37000M,
                    CreatedDate = new DateTimeOffset(1997,06,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 50,
                    Category = categories.Single(c=>c.CategoryName==("Self Help")),
                    Author = authors.Single(a=>a.AuthorName==("Dale Carnegie")),
                    Publisher = publishers.Single(p=>p.PublisherName==("First News - Trí Việt"))
                },

                new Book()
                {
                     Title = "Harry Potter And The Sorcerer's Stone",
                     Summary = "Khi một lá thư được gởi đến cho cậu bé Harry Potter bình thường và bất hạnh, cậu khám phá ra một bí mật đã được che giấu suốt cả một thập kỉ. Cha mẹ cậu chính là phù thủy và cả hai đã bị lời nguyền của Chúa tể Hắc ám giết hại khi Harry mới chỉ là một đứa trẻ, và bằng cách nào đó, cậu đã giữ được mạng sống của mình. Thoát khỏi những người giám hộ Muggle không thể chịu đựng nổi để nhập học vào trường Hogwarts, một trường đào tạo phù thủy với những bóng ma và phép thuật, Harry tình cờ dấn thân vào một cuộc phiêu lưu đầy gai góc khi cậu phát hiện ra một con chó ba đầu đang canh giữ một căn phòng trên tầng ba. Rồi Harry nghe nói đến một viên đá bị mất tích sở hữu những sức mạnh lạ kì, rất quí giá, vô cùng nguy hiểm, mà cũng có thể là mang cả hai đặc điểm trên.",
                     ImageUrl = "book-0003.jpg",
                     Price = 179000M,
                     CreatedDate = new DateTimeOffset(1997,06,26,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = false,
                     Quantity = 12,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Chamber Of Secrets",
                     Summary = "Vào năm học thứ 2 tại trường Hogwarts, Harry và các bạn tiếp tục đối mặt với những bài học thú vị mới và những bí mật mới. Người kế vị Slytherin đã gây ra nỗi kinh hoàng trong trường, với lời đồn đại về căn phòng chứa bí mật. Cuộc phiêu lưu của Harry và hai người bạn, Ron và Hermione, hấp dẫn hơn bao giờ hết nhờ minh họa sống động của họa sĩ Jim Kay. Harry Potter và Phòng chứa bí mật là tập 2 trong bộ sách Harry Potter với phiên bản có tranh minh họa.",
                     ImageUrl = "book-0004.jpg",
                     Price = 179000M,
                     CreatedDate = new DateTimeOffset(1998,07,02,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = false,
                     Quantity = 15,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Prisoner Of Azkaban",
                     Summary = "Harry Potter may mắn sống sót đến tuổi 13, sau nhiều cuộc tấn công của Chúa tể hắc ám. Nhưng hy vọng có một học kỳ yên ổn với Quidditch của cậu đã tiêu tan thành mây khói khi một kẻ điên cuồng giết người hàng loạt vừa thoát khỏi nhà tù Azkaban, với sự lùng sục của những cai tù là giám ngục. Dường như trường Hogwarts là nơi an toàn nhất cho Harry lúc này. Nhưng có phải là sự trùng hợp khi cậu luôn cảm giác có ai đang quan sát mình từ bóng đêm, và những điềm báo của giáo sư Trelawney liệu có chính xác? Câu chuyện được kể với trí tưởng tượng bay bổng, sự hài hước bất tận có thể quyến rũ cả người lớn lẫn trẻ em.",
                     ImageUrl = "book-0005.jpg",
                     Price = 179000M,
                     CreatedDate = new DateTimeOffset(1999,07,08,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = false,
                     Quantity = 21,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Goblet Of Fire",
                     Summary = "Khi giải Quidditch Thế giới bị cắt ngang bởi những kẻ ủng hộ Chúa tể Voldemort và sự trở lại của Dấu hiệu hắc ám khủng khiếp, Harry ý thức được rõ ràng rằng, Chúa tể Voldemort đang ngày càng mạnh hơn. Và để trở lại thế giới phép thuật, Chúa tể hắc ám cần phải đánh bại kẻ duy nhất sống sót từ lời nguyền chết chóc của hắn - Harry Potter. Vì lẽ đó, khi Harry bị buộc phải bước vào giải đấu Tam Pháp thuật uy tín nhưng nguy hiểm, cậu nhận ra rằng trên cả chiến thắng, cậu phải giữ được mạng sống của mình. Bốn năm của Harry cũng như của chúng tôi ở trường Hogwarts thật vui nhộn, một thế giới đầy hài hước cùng nhiều hoạt động thú vị.",
                     ImageUrl = "book-0006.jpg",
                     Price = 207000M,
                     CreatedDate = new DateTimeOffset(2000,07,08,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = false,
                     Quantity = 152,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Order Of The Phoenix",
                     Summary = "Harry tức giận vì bị bỏ rơi ở nhà Dursley trong dịp hè, cậu ngờ rằng Chúa tể hắc ám Voldemort đang tập hợp lực lượng, và vì cậu có nguy cơ bị tấn công, những người Harry luôn coi là bạn đang cố che giấu tung tích cậu. Cuối cùng, sau khi được giải cứu, Harry khám phá ra rằng giáo sư Dumbledore đang tập hợp lại Hội Phượng Hoàng – một đoàn quân bí mật đã được thành lập từ những năm trước nhằm chống lại Chúa tể Voldemort. Tuy nhiên, Bộ Pháp thuật không ủng hộ Hội Phượng Hoàng, những lời bịa đặt nhanh chóng được đăng tải trên Nhật báo Tiên tri – một tờ báo của giới phù thủy, Harry lo ngại rằng rất có khả năng cậu sẽ phải gánh vác trách nhiệm chống lại cái ác một mình. ‘Hoang đường nhưng không hoang tưởng, trí tưởng tượng của Rowling cùng sự táo bạo của cô đã tạo cho cô một phong cách riêng.’ - The Times.",
                     ImageUrl = "book-0007.jpg",
                     Price = 207000M,
                     CreatedDate = new DateTimeOffset(2003,06,21,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = true,
                     Quantity = 502,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Half-Blood Prince",
                     Summary = "Đây là năm thứ 6 của Harry Potter tại trường Hogwarts. Trong lúc những thế lực hắc ám của Voldemort gieo rắc nỗi kinh hoàng và sợ hãi ở khắp nơi, mọi chuyện càng lúc càng trở nên rõ ràng hơn đối với Harry, rằng cậu sẽ sớm phải đối diện với định mệnh của mình. Nhưng liệu Harry đã sẵn sàng vượt qua những thử thách đang chờ đợi phía trước? Trong cuộc phiêu lưu tăm tối và nghẹt thở nhất của mình, J.K.Rowling bắt đầu tài tình tháo gỡ từng mắc lưới phức tạp mà cô đã mạng lên, cũng là lúc chúng ta khám phá ra sự thật về Harry, cụ Dumblebore, thầy Snape và, tất nhiên, Kẻ Chớ Gọi Tên Ra… ‘Diễn biến nhanh, huyền bí, hấp dẫn và chặt chẽ trong từng chi tiết.'",
                     ImageUrl = "book-0008.jpg",
                     Price = 207000M,
                     CreatedDate = new DateTimeOffset(2005,07,16,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = true,
                     Quantity = 126,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Harry Potter And The Deathly Hallows",
                     Summary = "Harry đang chờ đợi ở trường Privet Drive. Hội Phượng Hoàng sắp đến hộ tống nó ra đi an toàn, gắng hết sức không để cho Voldemort và bọn tay chân hắn biết được. Nhưng sau đó Harry sẽ làm gì? Làm cách nào nó có thể hoàn thành nhiệm vụ cực kỳ quan trọng và dường như bất khả thi mà giáo sự Dumbledore đã giao lại cho nó?",
                     ImageUrl = "book-0009.jpg",
                     Price = 234000M,
                     CreatedDate = new DateTimeOffset(2007,07,21,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = true,
                     Quantity = 29,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },
                 new Book()
                 {
                     Title = "Fantastic Beasts And Where To Find Them",
                     Summary = "J.K. Rowling's screenwriting debut is captured in this exciting hardcover edition of the Fantastic Beasts and Where to Find Them screenplay. When Magizoologist Newt Scamander arrives in New York, he intends his stay to be just a brief stopover. However, when his magical case is misplaced and some of Newt's fantastic beasts escape, it spells trouble for everyone… Fantastic Beasts and Where to Find Them marks the screenwriting debut of J.K. Rowling, author of the beloved and internationally bestselling Harry Potter books. Featuring a cast of remarkable characters, this is epic, adventure-packed storytelling at its very best. Whether an existing fan or new to the wizarding world, this is a perfect addition to any reader's bookshelf.",
                     ImageUrl = "book-0010.jpg",
                     Price = 419000M,
                     CreatedDate = new DateTimeOffset(2001,03,01,0,0,0, new TimeSpan()),
                     ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                     IsActive = false,
                     Quantity = 234,
                     Category = categories.Single(c=>c.CategoryName==("Literature & Fiction")),
                     Author = authors.Single(a=>a.AuthorName==("J. K. Rowling")),
                     Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Trẻ"))
                 },

                 // Aoyama Gosho
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 1",
                    Summary = "Thám Tử Lừng Danh Conan Tập 1 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageUrl = "book-0011.jpg",
                    Price = 16000M,
                    CreatedDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2004,07,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 532,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Aoyama Gosho")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 2",
                    Summary = "Thám Tử Lừng Danh Conan Tập 2 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageUrl = "book-0012.jpg",
                    Price = 16000M,
                    CreatedDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 452,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Aoyama Gosho")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 3",
                    Summary = "Thám Tử Lừng Danh Conan Tập 3 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageUrl = "book-0013.jpg",
                    Price = 16000M,
                    CreatedDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2004,07,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 289,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Aoyama Gosho")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 4",
                    Summary = "Thám Tử Lừng Danh Conan Tập 4 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageUrl = "book-0014.jpg",
                    Price = 16000M,
                    CreatedDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 0,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Aoyama Gosho")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Thám Tử Lừng Danh Conan Tập 5",
                    Summary = "Thám Tử Lừng Danh Conan Tập 5 - Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ. Nhân vật chính của truyện là một thám tử học sinh trung học có tên là Kudo Shinichi - thám tử học đường xuất sắc - một lần bị bọn tội phạm ép uống thuốc độc và bị teo nhỏ thành học sinh tiểu học lấy tên là Conan Edogawa và luôn cố gắng truy tìm tung tích tổ chức Áo Đen nhằm lấy lại hình dáng cũ.",
                    ImageUrl = "book-0015.jpg",
                    Price = 16000M,
                    CreatedDate = new DateTimeOffset(2014,06,06,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 235,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Aoyama Gosho")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },

                // Eiichiro Oda

                new Book()
                {
                    Title = "One Piece - Tập 1",
                    Summary = "One Piece - Tập 1 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageUrl = "book-0016.jpg",
                    Price = 17000M,
                    CreatedDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 0,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Eiichiro Oda")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "One Piece - Tập 2",
                    Summary = "One Piece - Tập 2 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageUrl = "book-0017.jpg",
                    Price = 17000M,
                    CreatedDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 99,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Eiichiro Oda")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "One Piece - Tập 3",
                    Summary = "One Piece - Tập 3 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageUrl = "book-0018.jpg",
                    Price = 17000M,
                    CreatedDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 75,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Eiichiro Oda")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "One Piece - Tập 4",
                    Summary = "One Piece - Tập 4 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageUrl = "book-0019.jpg",
                    Price = 17000M,
                    CreatedDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 336,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Eiichiro Oda")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "One Piece - Tập 5",
                    Summary = "One Piece - Tập 5 - One Piece (Vua hải tặc) bộ thuộc thể loại truyện tranh Hành động kể về một cậu bé tên Monkey D. Luffy, giong buồm ra khơi trên chuyến hành trình tìm kho báu huyền thoại One Piece và trở thành Vua hải tặc. Để làm được điều này, cậu phải đến được tận cùng của vùng biển nguy hiểm và chết chóc nhất thế giới: Grand Line (Đại Hải Trình). Luffy đội trên đầu chiếc mũ rơm như một nhân chứng lịch sử vì chiếc mũ rơm đó đã từng thuộc về hải tặc hùng mạnh: Hải tặc vương Gol. D. Roger và tứ hoàng Shank \"tóc đỏ\". Luffy lãnh đạo nhóm hải tặc Mũ Rơm qua East Blue (Biển Đông) và rồi tiến đến Grand Line. Cậu theo dấu chân của vị vua hải tặc quá cố, Gol. D. Roger, chu du từ đảo này sang đảo khác để đến với kho báu vĩ đại.",
                    ImageUrl = "book-0020.jpg",
                    Price = 17000M,
                    CreatedDate = new DateTimeOffset(2015,09,26,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 390,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Eiichiro Oda")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },

                //Fujiko.F.Fujio
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 1 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0021.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2017,05,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 66,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Dài - Tập 2",
                    Summary = "Fujiko F Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 2 - Lâu đài dưới đáy biển, Chuyến phiêu lưu vào xứ quỷ, Cuộc chiến vũ trụ...!! 3 Chuyến phiêu lưu đầy kịch tính tiếp theo của Nobita và nhóm bạn sẽ đưa các bạn tới những vùng đất kì diệu đầy hoài niệm của tuổi thơ!! Đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko,Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. Bắt đầu từ tháng 10, 2 Series Doraemon truyện ngắn & dài thuộc Đại Tuyển tập Fujiko F Fujio sẽ ra mắt đều đặn mỗi tháng 1 cuốn xen kẽ. Đừng bỏ lỡ nhé các Fan của Mèo Ú!!",
                    ImageUrl = "book-0022.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2017,10,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 25,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Dài - Tập 3",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 3 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0023.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2017,11,05,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 116,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Dài - Tập 4",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 4 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0024.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2018,01,22,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 86,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Dài - Tập 5",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Dài - Tập 5 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0025.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2018,04,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 54,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 1 (Ấn Bản Kỉ Niệm 60 Năm NXB Kim Đồng)",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 1 (Ấn Bản Kỉ Niệm 60 Năm NXB Kim Đồng) Bộ sách là phiên bản tập hợp đầy đủ nhất các truyện ngắn Doraemon, trong đó đã bao gồm những truyện ngắn quen thuộc trong bộ 45 tập cùng những sáng tác chưa từng ra mắt của tác giả Fujiko F Fujio được đăng rải rác trên các tạp chí dành cho lứa tuổi Nhi Đồng tại Nhật Bản. Với độ dày gần 800 trang cho tập 1, đi kèm là những trang màu cùng lời tâm sự của tác giả chưa từng được công bố ở bất cứ đâu, đây chắc chắn sẽ là một trong những bộ sách ấn tượng trong series Doraemon nói riêng, cũng như loạt sách kỉ niệm 60 năm của NXB Kim Đồng. Đồng thời đây cũng là ấn phẩm đánh dấu chặng đường 25 năm đồng hành cùng độc giả Việt Nam của chú Mèo Ú đến từ tương lai Doraemon. ",
                    ImageUrl = "book-0026.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2017,05,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 458,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 2",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 2 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0027.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2017,11,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = false,
                    Quantity = 166,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 3",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 3 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0028.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2018,01,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 46,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 4",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 4 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0029.jpg",
                    Price = 130000M,
                    CreatedDate = new DateTimeOffset(2018,03,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 0,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                },
                new Book()
                {
                    Title = "Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 5",
                    Summary = "Fujiko F. Fujio Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 5 - Cũng giống như bộ truyện ngắn, đây là bộ tuyển tập gồm những chuyến phiêu lưu của Doraemon, Nobita và các bạn đến những vùng đất mới, vốn đã rất quen thuộc với độc giả nhiều thế hệ: Tới vương quốc trên mây, nước Nhật thời nguyên thủy, Khai phá vũ trụ, hành tinh muông thú... Với độ dày hơn 600 trang cho một cuốn, đi kèm tập hợp những trang bản thảo màu và tâm sự của tác giả Fujiko, Tuyển tập truyện dài sẽ là một ấn phẩm đặc biệt nữa về Doraemon dành cho những độc giả muốn sưu tập lại những câu chuyện đầy hấp dẫn và lôi cuốn, với những bài học sâu sắc và ý nghĩa còn mãi với tuổi thơ. ",
                    ImageUrl = "book-0030.jpg",
                    Price = 123000M,
                    CreatedDate = new DateTimeOffset(2018,05,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true,
                    Quantity = 5,
                    Category = categories.Single(c=>c.CategoryName==("Manga, Comic")),
                    Author = authors.Single(a=>a.AuthorName==("Fujiko.F.Fujio")),
                    Publisher = publishers.Single(p=>p.PublisherName==("Nhà xuất bản Kim Đồng"))
                }
            };

            books.ForEach(s => context.Books.Add(s));
            context.SaveChanges();

            #endregion

            #region Add Reviews

            var reviews = new List<Review>
            {
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("How To Win Friends And Influence People")).BookId,
                    Comment = "Comment 01 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("How To Stop Worrying And Start Living")).BookId,
                    Comment = "Comment 02 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Sorcerer's Stone")).BookId,
                    Comment = "Comment 03 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Chamber Of Secrets")).BookId,
                    Comment = "Comment 04 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Prisoner Of Azkaban")).BookId,
                    Comment = "Comment 05 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Goblet Of Fire")).BookId,
                    Comment = "Comment 06 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Order Of The Phoenix")).BookId,
                    Comment = "Comment 07 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Harry Potter And The Half-Blood Prince")).BookId,
                    Comment = "Comment 08 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 5")).BookId,
                    Comment = "Comment 09 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Thám Tử Lừng Danh Conan Tập 1")).BookId,
                    Comment = "Comment 10 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("One Piece - Tập 1")).BookId,
                    Comment = "Comment 01 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("One Piece - Tập 2")).BookId,
                    Comment = "Comment 02 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("One Piece - Tập 3")).BookId,
                    Comment = "Comment 03 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("One Piece - Tập 4")).BookId,
                    Comment = "Comment 04 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Thám Tử Lừng Danh Conan Tập 2")).BookId,
                    Comment = "Comment 05 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Thám Tử Lừng Danh Conan Tập 3")).BookId,
                    Comment = "Comment 06 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Thám Tử Lừng Danh Conan Tập 4")).BookId,
                    Comment = "Comment 07 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Thám Tử Lừng Danh Conan Tập 5")).BookId,
                    Comment = "Comment 08 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 4")).BookId,
                    Comment = "Comment 09 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                },
                new Review()
                {
                    BookId = books.Single(b=>b.Title==("Đại Tuyển Tập - Doraemon Truyện Ngắn - Tập 3")).BookId,
                    Comment = "Comment 10 Thám Tử Lừng Danh Conan là một bộ truyện tranh trinh thám Nhật Bản của tác giả Aoyama Gõshõ",
                    CreatedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    ModifiedDate = new DateTimeOffset(2018,08,25,0,0,0, new TimeSpan()),
                    IsActive = true
                }
            };
            reviews.ForEach(s => context.Reviews.Add(s));
            context.SaveChanges();

            #endregion

            #region Roles
            //var roles = new List<ApplicationRole>
            //{
            //    new ApplicationRole()
            //    {
            //        Name = "Administrators"
            //    },
            //    new ApplicationRole()
            //    {
            //        Name = "Manager"
            //    },
            //    new ApplicationRole()
            //    {
            //        Name = "Seller"
            //    }
            //};
            //roles.ForEach(s => context.Roles.Add(s));
            //context.SaveChanges();

            #endregion

            #region Users
            //var passwordHasher = new PasswordHasher();
            //var users = new List<ApplicationUser>
            //{

            //    new ApplicationUser()
            //    {
            //        Name = "Cong Dinh",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Nam Dinh",
            //        Address = "Y Yen",
            //        Photo = "avatar-1.png",
            //        Email = "cong@domain.com",
            //        UserName = "cong@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Abc@1234"),
            //        EmailConfirmed = true,
            //        PhoneNumber = "0944551356",
            //        PhoneNumberConfirmed = true,
            //        LockoutEnabled=true,
            //        AccessFailedCount=0,
            //        TwoFactorEnabled = false
            //    },
            //    new ApplicationUser()
            //    {
            //        Name = "Van Nguyen",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Thai Binh",
            //        Address = "Hung Ha",
            //        Photo = "avatar-2.png",
            //        Email = "van@domain.com",
            //        UserName = "van@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Abc@1234"),
            //        EmailConfirmed = true,
            //        PhoneNumber = "0944551356",
            //        PhoneNumberConfirmed = true,
            //        LockoutEnabled=true,
            //        AccessFailedCount=0,
            //        TwoFactorEnabled = false
            //    },
            //    new ApplicationUser()
            //    {
            //        Name = "Quynh Dinh",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Can Tho",
            //        Address = "Ninh Kieu",
            //        Photo = "avatar-3.png",
            //        Email = "quynh@domain.com",
            //        UserName = "quynh@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Abc@1234"),
            //        EmailConfirmed = true,
            //        PhoneNumber = "0944551356",
            //        PhoneNumberConfirmed = true,
            //        LockoutEnabled=true,
            //        AccessFailedCount=0,
            //        TwoFactorEnabled = false
            //    },
            //    new ApplicationUser()
            //    {
            //        Name = "Anh Hien",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Ha Noi",
            //        Address = "Thach That",
            //        Photo = "avatar-4.png",
            //        Email = "hien@domain.com",
            //        UserName = "hien@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Abc@1234"),
            //        EmailConfirmed = true,
            //        PhoneNumber = "0944551356",
            //        PhoneNumberConfirmed = true,
            //        LockoutEnabled=true,
            //        AccessFailedCount=0,
            //        TwoFactorEnabled = false
            //    },
            //};
            //users.ForEach(s => context.Users.Add(s));
            //context.SaveChanges();
            #endregion

            #region Employees
            //var employees = new List<Employee>
            //{

            //    new Employee()
            //    {
            //        Name = "Cong Dinh",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Nam Dinh",
            //        Address = "Y Yen",
            //        Photo = "avatar-5.png",
            //        Email = "cong@domain.com",
            //        PhoneNumber = "0944551356",
            //        UserName = "cong@domain.com",
            //        Password = "Abc@1234"
            //    },
            //    new Employee()
            //    {
            //        Name = "Van Nguyen",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Thai Binh",
            //        Address = "Hung Ha",
            //        Photo = "avatar-6.png",
            //        Email = "van@domain.com",
            //        PhoneNumber = "0944551356",
            //        UserName = "van@domain.com",
            //        Password = "Abc@1234"
            //    },
            //    new Employee()
            //    {
            //        Name = "Quynh Dinh",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Can Tho",
            //        Address = "Ninh Kieu",
            //        Photo = "avatar-7.png",
            //        Email = "quynh@domain.com",
            //        PhoneNumber = "0944551356",
            //        UserName = "quynh@domain.com",
            //        Password = "Abc@1234"
            //    },
            //    new Employee()
            //    {
            //        Name = "Hien Nguyen",
            //        BirthDate = new DateTime(2004,07,26),
            //        City = "Ha Noi",
            //        Address = "Thach That",
            //        Photo = "avatar-8.png",
            //        Email = "hien@domain.com",
            //        PhoneNumber = "0944551356",
            //        UserName = "hien@domain.com",
            //        Password = "Abc@1234"
            //    },
            //};
            //employees.ForEach(s => context.Employees.Add(s));
            //context.SaveChanges();
            #endregion
        }
    }
}
