using System;
using System.Collections.Generic;
using baocao.Properties;

namespace baocao.GUI.Managers
{
    public class LanguageManager
    {
        private static LanguageManager instance;
        public static LanguageManager Instance => instance ?? (instance = new LanguageManager());

        private Dictionary<string, Dictionary<string, string>> translations;
        private string currentLanguage;

        public string CurrentLanguage
        {
            get => currentLanguage;
            private set
            {
                currentLanguage = value;
                // Lưu vào Settings
                Settings.Default.CurrentLanguage = value;
                Settings.Default.Save();
            }
        }

        public event EventHandler LanguageChanged;

        // Constructor duy nhất (private) để đảm bảo singleton
        private LanguageManager()
        {
            LoadDefaultTranslations();

            // Đọc ngôn ngữ đã lưu từ Settings
            string savedLang = Settings.Default.CurrentLanguage;
            if (!string.IsNullOrEmpty(savedLang) && translations.ContainsKey(savedLang))
                currentLanguage = savedLang;
            else
                currentLanguage = "vi";
        }


        private void LoadDefaultTranslations()
        {
            translations = new Dictionary<string, Dictionary<string, string>>();
            translations["vi"] = new Dictionary<string, string>
        {
            { "language", "Ngôn ngữ" },
            { "display_language_settings", "Cài đặt ngôn ngữ hiển thị" },
            {"system", "Hệ thống" },
            {"system_settings","Cài đặt hệ thống, chế độ tối, \nsao lưu và khôi phục" },
            {"company","Danh mục khách hàng" },
            {"partner_company_info", "Thông tin các công ty đối tác" },
            {"account", "Tài khoản" },
            {"account_info_security","Thông tin tài khoản, \nBảo mật thông tin tài khoản" },
            {"cloudsync", "  Đồng bộ"},
            {"buildversion", "   Phiên bản" },
            { "start", "Bắt Đầu" },
            { "stop", "Kết thúc" },
            { "ai_language_title", "AI Tiếng Việt" },
            {"search", "Tìm kiếm" },
            { "company_code", "   Mã công ty" },
            { "company_name", "Tên công ty" },
            { "company_symbol", " Ký hiệu công ty" },
            { "representative", "Người đại diện" },
            { "phone_number", "   Số điện thoại" },
            { "address", "Địa chỉ" },
            {"save", "Lưu" },
            {"cancel", "Hủy" },
            {"add_company", "Thêm công ty"},
            {"edit_company", "Chỉnh sửa công ty" },
            { "login_ready", " Sẵn sàng" },
            { "forgot_password", "Quên mật khẩu" },
            { "login", " Đăng nhập" },
            { "login_error", "Tên đăng nhập hoặc mật khẩu không đúng" },
            { "password_placeholder", "Mật Khẩu" },
            { "username_placeholder", "Tên Đăng Nhập" },
            { "btn_login", "Đăng nhập" },
            { "DonHang", "Đơn hàng" },
            { "CongTy", "Công ty" },
            {"remember","Ghi nhớ tài khoản" },
            {"DelTS","Xóa thông số" },
            {"InsertTS","Thêm thông số" },
            {"thong_so_title","Thông số môi trường" },
            {"new_password","Mật khẩu mới" },
            {"confirm_password", "Nhập lại mật khẩu mới" },
            {"btn_confirm", "Xác nhận" },
            {"new_password_placeholder", "Nhập lại mật khẩu mới" },
            { "confirm_password_placeholder", "Nhập lại mật khẩu" },
            {"form_reset_password", "Đặt lại mật khẩu" },
            { "contract_code", "    Mã hợp đồng" },
            { "order_code", "    Mã đơn hàng" },
            { "created_date", "   Ngày lấy mẫu" },
            { "result_date", "  Ngày trả kết quả" },
            { "quarter", "   Quý" },
            { "status", "   Trạng thái" },
            { "serial_number", "Số thứ tự" },
            { "parameter_code", "Mã thông số" },
            { "parameter_name", "Tên thông số" },
            { "unit", "Đơn vị" },
            { "result", "Kết quả" },
            { "previous_result", "Kết quả quý trước" },
            { "hide_inspection", "Ẩn lần quan trắc" },
            { "type", "Loại" },
            { "analyst", "Người phân tích" },
            { "standard_value", "Giá trị quy chuẩn TCVN" },
            { "conclusion", "Kết luận" },
            {"overdue", "Quá hạn" },
            {"in_progress","Đang xử lý" },
            {"completed","Hoàn thành" },
            {"environmental_parameters"," Thông số môi trường" },
            {"view", "Xem" },
            { "sample_start_date", "Ngày bắt đầu lấy mẫu" },
            { "estimated_result_date", "Ngày trả kết quả dự kiến" },
            { "add_order", "Thêm đơn hàng" },
            { "edit_order", "Chỉnh sửa đơn hàng" },
            { "contract_form_title", "Danh sách hợp đồng" },
            { "contract_date", "   Ngày ký hợp đồng" },
            { "soil", "Đất" },
            { "water", "Nước" },
            { "air", "Không khí" },
            { "waste_gas", "Khí thải" },
            {"edit_contract","Chỉnh sửa hợp đồng" },
            {"add_contract", "Thêm hợp đồng"},
            { "home", "Trang chủ" },
            { "thong_ke", "Thống kê" },
            { "guide", "Hướng dẫn sử dụng" },
            { "manage", "Quản lý và phân quyền" },
            { "settings", "Cài đặt" },
            {"order_list", "Danh sách đơn hàng" },
            { "user_id", "   Mã nhân viên" },
            { "full_name", " Họ và tên" },
            { "role", "Phòng ban" },
            { "username", "Tên đăng nhập" },
            { "email", "   Email" },
            { "add_user", "Thêm nhân viên" },
            { "edit_user", "Chỉnh sửa nhân viên" },
            { "otp", "Mã OTP" },
            { "keep_your_password", "Keep your password" },
            { "send_otp", "Gửi OTP" },
            { "verify", "Xác nhận" },
            {"page", "Trang" },
            {"permission_management", "Quản lý phân quyền" },
            { "role_admin", "Quản trị viên" },
            { "role_sales", "Phòng kinh doanh" },
            { "role_inspection", "Phòng quan trắc" },
            { "role_analysis", "Phòng phân tích" },
            { "role_planning", "Phòng kế hoạch" },
            { "role_results", "Phòng xuất kết quả" },
            {"update", "Cập nhật" },
            {"employee_id", "Mã nhân viên" },
            {"change_password", "Đổi mật khẩu" },
            { "edit_info", "Sửa thông tin" },
            {"password", "Mật khẩu" },
            {"logout", "Đăng xuất" },
            { "user_name", "Tên đăng nhập" },
            {"account_form_title", "Thông tin tài khoản" },
            {"statistics_form_title", "Tiêu đề biểu đồ thống kê"},
            {"year", "Năm"},
            {"quarterly_order_status_chart", "Biểu đồ trạng thái đơn hàng theo quý"},
            { "sound_error", "Lỗi khi xử lý âm thanh: " },
            { "empty_company_fields", "Mã công ty và tên công ty không được để trống!" },
            { "input_error", "Lỗi nhập liệu" },
            { "update_success", "Cập nhật thành công!" },
            { "insert_success", "Thêm mới thành công!" },
            { "notification", "Thông báo" },
            { "operation_failed", "Thao tác thất bại!" },
            { "error", "Lỗi" },
            { "save_before_exit", "Bạn có muốn lưu trước khi thoát?" },
            { "confirmation", "Xác nhận" },
            { "empty_fullname", "Họ tên không được để trống" },
            { "empty_username", "Tên đăng nhập không được để trống" },
            { "empty_email", "Email không được để trống" },
            { "empty_phone", "Số điện thoại không được để trống" },
            { "empty_role", "Vai trò không được để trống" },
            { "empty_contract_fields", "Vui lòng nhập đầy đủ thông tin!" },
            { "order_list_status", "Danh sách đơn hàng có trạng thái '{0}':\n" },
            { "order_id", "Mã đơn hàng: {0}" },
            { "order_details", "Chi tiết đơn hàng" },
            { "no_orders_in_status", "Không có đơn hàng nào ở trạng thái này!" },
            {"password_mismatch", "Mật khẩu mới không khớp" },
            { "update_failed", "Cập nhật thất bại" },

             {"contract_code1", "Mã hợp đồng" },
             {"company_code1", "Mã công ty" },
             {"company_name1", "Tên công ty" },
             { "company_symbol1", " Ký hiệu công ty" },
             { "representative1", "Người đại diện" },
             { "phone_number1", "Số điện thoại" },
             { "address1", "Địa chỉ" },
             { "contract_date1", "Ngày ký hợp đồng" },

             { "order_code1", "    Mã đơn hàng" },
             { "created_date1", "    Ngày lập" },
             { "result_date1", "  Ngày trả kết quả" },
             { "quarter1", "   Quý" },
             { "status1", "   Trạng thái" },

            { "user_id1", "Mã nhân viên" },
            { "full_name1", "Họ và tên" },
            { "role1", "Phòng ban" },
            { "username1", "Tên đăng nhập" },
            { "email1", "Email" },
            { "overview", "1. Tổng quan về doanh nghiệp\nCông ty Phân tích Môi trường là một đơn vị chuyên cung cấp các dịch vụ kiểm tra, phân tích và đánh giá chất lượng môi trường, bao gồm các lĩnh vực như nước, không khí, đất và nước thải công nghiệp. Ngoài việc cung cấp dịch vụ phân tích mẫu, công ty còn tư vấn các giải pháp xử lý môi trường, hỗ trợ doanh nghiệp trong việc tuân thủ các quy định pháp lý, giảm thiểu tác động tiêu cực đến môi trường và đảm bảo sự phát triển bền vững. Công ty phục vụ đa dạng đối tượng khách hàng, từ các doanh nghiệp sản xuất, khu công nghiệp, cơ quan quản lý môi trường cho đến các tổ chức nghiên cứu và trường đại học. Bằng việc áp dụng công nghệ tiên tiến, công ty không ngừng cải tiến quy trình phân tích nhằm nâng cao hiệu suất làm việc và chất lượng dịch vụ." },

            { "orientation", "2. Định hướng doanh nghiệp\nCông ty hướng đến việc trở thành đơn vị tiên phong trong lĩnh vực phân tích môi trường, cung cấp các giải pháp toàn diện từ lấy mẫu, phân tích đến tư vấn giải pháp xử lý ô nhiễm. Trong thời đại công nghệ phát triển nhanh chóng, công ty tập trung vào việc ứng dụng các công nghệ mới vào quy trình phân tích nhằm tối ưu hóa độ chính xác, tiết kiệm thời gian và nâng cao tính cạnh tranh trên thị trường. Bên cạnh đó, công ty cũng đẩy mạnh hợp tác với các tổ chức khoa học, trường đại học và doanh nghiệp trong và ngoài nước để nghiên cứu và phát triển các phương pháp phân tích tiên tiến. Việc đầu tư vào công nghệ và con người là hai yếu tố quan trọng giúp công ty duy trì vị thế dẫn đầu và không ngừng mở rộng phạm vi hoạt động. Trong tương lai, công ty hướng tới xây dựng hệ thống quản lý chất lượng đạt chuẩn quốc tế, mở rộng quy mô hoạt động không chỉ trong nước mà còn vươn ra thị trường quốc tế. Đồng thời, công ty cũng thực hiện trách nhiệm xã hội bằng cách tham gia các chương trình bảo vệ môi trường và nâng cao nhận thức cộng đồng về vấn đề ô nhiễm môi trường." },
    
            { "objectives", "3. Mục tiêu kinh doanh\n- Cung cấp dịch vụ phân tích môi trường chính xác, nhanh chóng và đáng tin cậy, giúp khách hàng tuân thủ quy định pháp luật và nâng cao chất lượng môi trường.\n- Ứng dụng công nghệ tiên tiến vào quá trình phân tích, nâng cao độ chính xác và tối ưu hóa thời gian xử lý mẫu.\n- Mở rộng danh mục khách hàng, bao gồm doanh nghiệp sản xuất, khu công nghiệp, cơ quan nhà nước, tổ chức nghiên cứu và cộng đồng.\n- Xây dựng thương hiệu uy tín, tạo niềm tin và sự hài lòng của khách hàng thông qua chất lượng dịch vụ và sự chuyên nghiệp trong làm việc.\n- Tăng cường hợp tác với các tổ chức trong và ngoài nước nhằm nghiên cứu và phát triển các giải pháp phân tích môi trường hiện đại.\n- Đảm bảo các tiêu chuẩn quản lý chất lượng và an toàn trong tất cả các quy trình hoạt động." },

            { "infrastructure", "4. Cơ sở hạ tầng\nĐể đạt được mục tiêu kinh doanh và cung cấp dịch vụ phân tích chất lượng cao, công ty đảm bảo hệ thống cơ sở hạ tầng hiện đại, bao gồm:\n- Phòng thí nghiệm đạt chuẩn: Được trang bị các thiết bị phân tích tiên tiến.\n- Hệ thống lưu trữ và quản lý dữ liệu: Xây dựng cơ sở dữ liệu tập trung để lưu trữ và quản lý kết quả phân tích, đảm bảo tính bảo mật và truy xuất dữ liệu dễ dàng.\n- Phần mềm quản lý thông tin: Hỗ trợ quá trình đặt hàng, theo dõi tiến độ phân tích, xuất báo cáo kết quả và tương tác với khách hàng.\n- Hạ tầng công nghệ thông tin: Đảm bảo hệ thống mạng ổn định, máy chủ bảo mật, trang thiết bị hiện đại để phục vụ nhu cầu vận hành và xử lý dữ liệu.\n- Hệ thống kiểm soát chất lượng: Xây dựng quy trình kiểm soát chất lượng theo các tiêu chuẩn quốc tế nhằm đảm bảo độ chính xác và tính nhất quán trong các kết quả phân tích.\n- Cơ sở vật chất hỗ trợ: Bao gồm văn phòng làm việc, khu vực tiếp khách, kho lưu trữ mẫu và các khu vực hỗ trợ khác nhằm đảm bảo hoạt động của công ty diễn ra suôn sẻ." },

            { "budget", "5. Ngân sách\nNgân sách dành cho việc triển khai phần mềm quản lý đơn hàng môi trường bao gồm các khoản chi cơ bản như:\n- Chi phí hạ tầng: Bao gồm đầu tư vào máy chủ, thiết bị lưu trữ và nâng cấp hệ thống mạng nếu cần.\n- Chi phí phần mềm: Gồm các giấy phép sử dụng hệ quản trị cơ sở dữ liệu, hệ điều hành và các công cụ phát triển phần mềm.\n- Chi phí bảo trì và hỗ trợ: Dự toán chi phí định kỳ để bảo trì hệ thống, cập nhật phần mềm và hỗ trợ kỹ thuật khi có sự cố.\n- Chi phí đào tạo: Dành cho việc hướng dẫn nhân viên sử dụng phần mềm hiệu quả.\nNgân sách cụ thể sẽ được điều chỉnh dựa trên quy mô và nhu cầu thực tế của doanh nghiệp." }
};

            translations["en"] = new Dictionary<string, string>
        {
            { "language", "Language" },
            { "display_language_settings", "Display Language Settings" },
            {"system", "System" },
            {"system_settings","System settings, dark mode, \nbackup and restore" },
            {"company","Customer List" },
            {"partner_company_info", "Information of partner companies" },
            {"account", "Account" },
            {"account_info_security","Account Information, \nAccount Information Security" },
            {"cloudsync", "Cloud Sync"},
            {"buildversion","Build Versions"},
            { "start", "Start" },
            { "stop", "Stop" },
            { "ai_language_title", "AI Vietnamese" },
            {"search", "Searching" },
            { "company_code", "   Company Code" },
            { "company_name", "Company Name" },
            { "company_symbol", "Company Symbol" },
            { "representative", "Agent" },
            { "phone_number", "   Phone Number" },
            { "address", "Address" },
            {"save", "Save" },
            {"cancel", "Cancel" },
            {"add_company", "Add Company" },
            {"edit_company", "Edit Company" },
            { "login_ready", "   Ready" },
            { "forgot_password", "Forgot Password" },
            { "login", "     Login" },
            { "login_error", "        Incorrect username or password" },
            { "password_placeholder", "Password" },
            { "username_placeholder", "Username" },
            { "btn_login", "Login" },
            { "DonHang", "Contract Order" },
            { "CongTy", "Company" },
            {"remember","Remember Me" },
            {"DelTS","Delete" },
            {"InsertTS","Insert Parameter" },
            {"thong_so_title","Specification" },
            {"new_password","New Password" },
            {"confirm_password", "        Confirm Password" },
            {"btn_confirm", "Confirm" },
            {"new_password_placeholder", "Input new password" },
            { "confirm_password_placeholder", "Confirm password" },
            {"form_reset_password", "Reset password" },
            { "contract_code", "   Contract Code" },
            { "order_code", "   Order Code" },
            { "created_date", "   Created Date" },
            { "result_date", "   Result Date" },
            { "quarter", "   Quarter" },
            { "status", "   Status" },
            { "serial_number", "Serial number" },
            { "parameter_code", "Parameter code" },
            { "parameter_name", "Parameter name" },
            { "unit", "Unit" },
            { "result", "Result" },
            { "previous_result", "Previous quarter result" },
            { "hide_inspection", "Hide inspection" },
            { "type", "Type" },
            { "analyst", "Analyst" },
            { "standard_value", "TCVN Standard Value" },
            { "conclusion", "Conclusion" },
            {"overdue", "Overdue" },
            {"in_progress","In Progress" },
            {"completed","Completed" },
            {"environmental_parameters", " Environmental Specification" },
            {"view", "View" },
            { "sample_start_date", "Sample Start Date" },
            { "estimated_result_date", "Estimated Result Date" },
            { "add_order", "Add Order" },
            { "edit_order", "Edit Order" },
            { "contract_form_title", "Contract List" },
            { "contract_date", "    Contract Date" },
            { "soil", "Soil" },
            { "water", "Water" },
            { "air", "Air" },
            { "waste_gas", "Emission" },
            {"edit_contract","Edit Contract" },
            {"add_contract", "Add Contract"},
            { "home", "Home" },
            { "thong_ke", "Statistics" },
            { "guide", "Guide" },
            { "manage", "Manage" },
            { "settings", "Settings" },
            {"order_list", "Order List" },
            { "user_id", "    User ID" },
            { "full_name", "  Full Name" },
            { "role", "Role" },
            { "username", "Username" },
            { "email", "   Email" },
            { "add_user", "Add User" },
            { "edit_user", "Edit User" },
            { "keep_your_password", "Keep your password" },
            { "send_otp", "Send OTP" },
            { "verify", "Verify" },
            {"page", "Page" },
            { "permission_management", "Permission Management" },
            { "role_admin", "Administrator" },
            { "role_sales", "Sales Department" },
            { "role_inspection", "Inspection Department" },
            { "role_analysis", "Analysis Department" },
            { "role_planning", "Planning Department" },
            { "role_results", "Results Department" },
            {"update", "Update" },
            {"employee_id", "Employee ID" },
            {"change_password", "Change password" },
            { "edit_info", "Edit Information" },
            {"password", "Password" },
            {"logout", "Log out" },
            {"account_form_title", "Accoutn Information" },
            { "statistics_form_title", "Statistics Form Title" },
            { "year", "Year" },
            { "quarterly_order_status_chart", "Quarterly Order Status Chart" },
            { "sound_error", "Error processing audio: " },
            { "empty_company_fields", "Company code and company name must not be empty!" },
            { "input_error", "Input Error" },
            { "update_success", "Update succeeded!" },
            { "insert_success", "Insert succeeded!" },
            { "notification", "Notification" },
            { "operation_failed", "Operation failed!" },
            { "error", "Error" },
            { "save_before_exit", "Do you want to save before exiting?" },
            { "confirmation", "Confirmation" },
            { "empty_fullname", "Full name must not be empty" },
            { "empty_username", "Username must not be empty" },
            { "empty_email", "Email must not be empty" },
            { "empty_phone", "Phone number must not be empty" },
            { "empty_role", "Role must not be empty" },
            { "empty_contract_fields", "Please fill in all required fields!" },
            { "order_list_status", "List of orders with status '{0}':\n" },
            { "order_id", "Order ID: {0}" },
            { "order_details", "Order Details" },
            { "no_orders_in_status", "There are no orders in this status!" },
            {"password_mismatch", "New password does not match" },
            { "update_failed", "Update failed" },

            {"contract_code1", "Contract Code" },
            {"company_code1", "Company Code" },
            {"company_name1", "Company Name" },
            { "company_symbol1", "Company Symbol" },
            { "representative1", "Agent" },
            { "phone_number1", "Phone Number" },
            { "address1", "Address" },
            { "contract_date1", "Contract Date" },

            { "order_code1", "Order Code" },
            { "created_date1", "Created Date" },
            { "result_date1", "Result Date" },
            { "quarter1", "Quarter" },
            { "status1", "Status" },

            { "user_id1", "User ID" },
            { "full_name1", "Full Name" },
            { "role1", "Role" },
            { "username1", "Username" },
            { "email1", "Email" },
            { "overview", "1. Overview of the Company\nEnvironmental Analysis Company is a unit specialized in providing services for environmental testing, analysis, and evaluation, covering areas such as water, air, soil, and industrial wastewater. In addition to offering sample analysis services, the company also advises on environmental treatment solutions, supports businesses in complying with legal regulations, reduces negative environmental impacts, and ensures sustainable development. The company serves a diverse range of clients, including manufacturing companies, industrial zones, environmental regulatory agencies, research organizations, and universities. By applying advanced technology, the company continuously improves its analysis processes to enhance work efficiency and service quality." },

            { "orientation", "2. Business Orientation\nThe company aims to become a pioneer in the field of environmental analysis, offering comprehensive solutions from sample collection and analysis to pollution treatment consulting. In this era of rapid technological advancement, the company focuses on applying new technologies to its analysis processes to optimize accuracy, save time, and enhance market competitiveness. Moreover, the company actively promotes collaboration with scientific organizations, universities, and both domestic and international businesses to research and develop advanced analytical methods. Investing in technology and human resources is crucial for the company to maintain its leading position and continuously expand its scope of operations. In the future, the company intends to build a quality management system that meets international standards, expanding its operations both domestically and internationally. Simultaneously, the company fulfills its social responsibility by participating in environmental protection programs and raising community awareness about environmental pollution issues." },

            { "objectives", "3. Business Objectives\n- Provide accurate, fast, and reliable environmental analysis services that help customers comply with legal regulations and improve environmental quality.\n- Apply advanced technology in the analysis process to enhance accuracy and optimize sample processing time.\n- Expand the customer base to include manufacturing companies, industrial zones, government agencies, research organizations, and the community.\n- Build a reputable brand that instills trust and customer satisfaction through quality service and professional conduct.\n- Enhance collaboration with domestic and international organizations to research and develop modern environmental analysis solutions.\n- Ensure adherence to quality management and safety standards in all operational processes." },

            { "infrastructure", "4. Infrastructure\nTo achieve business objectives and deliver high-quality analysis services, the company maintains a modern infrastructure system, including:\n- Standardized laboratories: Equipped with advanced analytical instruments.\n- Data storage and management systems: A centralized database for storing and managing analysis results, ensuring data security and easy retrieval.\n- Information management software: Supporting order placement, tracking analysis progress, issuing result reports, and facilitating customer interaction.\n- IT infrastructure: Ensuring a stable network system, secure servers, and modern equipment to support operational and data processing needs.\n- Quality control systems: Establishing quality control procedures in line with international standards to ensure the accuracy and consistency of analysis results.\n- Supporting facilities: Including office spaces, reception areas, sample storage warehouses, and other support areas to ensure smooth company operations." },

            { "budget", "5. Budget\nThe budget allocated for implementing the environmental order management software includes basic expenses such as:\n- Infrastructure costs: Investment in servers, storage devices, and network system upgrades if necessary.\n- Software costs: Including licenses for database management systems, operating systems, and software development tools.\n- Maintenance and support costs: Estimated periodic expenses for system maintenance, software updates, and technical support in case of issues.\n- Training costs: For training employees to use the software effectively.\nThe specific budget will be adjusted based on the company's scale and actual needs." }
        };
    }

        public void SetLanguage(string lang)
        {
            if (translations.ContainsKey(lang))
            {
                CurrentLanguage = lang;
                // Phát sự kiện thông báo cho tất cả các form đang lắng nghe
                LanguageChanged?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine($"Ngôn ngữ {lang} không tồn tại! Giữ nguyên {CurrentLanguage}.");
            }
        }

        public string Translate(string key)
        {
            if (translations.ContainsKey(currentLanguage) && translations[currentLanguage].ContainsKey(key))
                return translations[currentLanguage][key];

            return key; // Trả về key nếu không có bản dịch
        }

        public void AddTranslation(string language, string key, string value)
        {
            if (!translations.ContainsKey(language))
            {
                translations[language] = new Dictionary<string, string>();
            }
            translations[language][key] = value;
        }
    }
}
