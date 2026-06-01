(function () {
  "use strict";

  const lang = document.documentElement.lang || "tr";
  if (!lang.toLowerCase().startsWith("en")) {
    return;
  }

  const exact = {
    "İnşaat Şantiye Yönetimi": "Construction Site Management",
    "Şantiye Yönetimi": "Site Management",
    "İnşaat Şirketi Şantiye ve Malzeme Yönetim Sistemi": "Construction Company Site and Material Management System",
    "Menüyü aç veya kapat": "Toggle menu",
    "Dil seçimi": "Language selection",
    "Dashboard": "Dashboard",
    "Projeler": "Projects",
    "Müşteriler": "Clients",
    "Malzemeler": "Materials",
    "Malzeme Türleri": "Material Types",
    "Tedarikçiler": "Suppliers",
    "Malzeme Alımları": "Material Purchases",
    "Taşeronlar": "Subcontractors",
    "İşçiler": "Workers",
    "İşçi Ödemeleri": "Worker Payments",
    "Proje Gelirleri": "Project Incomes",
    "Giderler": "Expenses",
    "SQL Sorguları": "SQL Queries",
    "Giriş Yap": "Sign In",
    "Çıkış": "Logout",
    "Kullanıcı": "User",
    "Kapat": "Close",
    "Gizlilik": "Privacy",
    "Bu uygulama yerel geliştirme ortamında çalışacak şekilde hazırlanmıştır. Giriş bilgileri, proje kayıtları ve finansal taslaklar uygulamanın bağlı olduğu SQL Server veritabanında tutulur.": "This app is designed to run in a local development environment. Login data, project records and financial drafts are stored in the connected SQL Server database.",

    "Proje, gelir, malzeme, işçilik ve şantiye giderlerinin genel özeti.": "General overview of projects, income, materials, labor payments and site expenses.",
    "Yeni Proje Ekle": "Add New Project",
    "Toplam Proje Sayısı": "Total Projects",
    "Aktif Proje Sayısı": "Active Projects",
    "Toplam Sözleşme Bedeli": "Total Contract Amount",
    "Net Kar / Zarar": "Net Profit / Loss",
    "Toplam Proje Geliri": "Total Project Income",
    "Toplam Malzeme Alım Maliyeti": "Total Material Purchase Cost",
    "Toplam İşçi Ödemesi": "Total Worker Payment",
    "Toplam Gider": "Total Expense",
    "Son Projeler": "Recent Projects",
    "Tümünü Gör": "View All",
    "Proje": "Project",
    "Müşteri": "Client",
    "Lokasyon": "Location",
    "Durum": "Status",
    "Sözleşme Bedeli": "Contract Amount",
    "Başlangıç": "Start",
    "Başlangıç Tarihi": "Start Date",
    "Bitiş Tarihi": "End Date",
    "Açıklama": "Description",
    "Listeye Dön": "Back to List",
    "Kaydet": "Save",
    "Vazgeç": "Cancel",
    "Düzenle": "Edit",
    "Sil": "Delete",
    "Detay": "Details",
    "İşlemler": "Actions",
    "İşlem": "Action",
    "Telefon": "Phone",
    "Adres": "Address",
    "Ad Soyad": "Full Name",
    "Firma": "Company",
    "Firma Adı": "Company Name",
    "Yetkili Kişi": "Contact Person",
    "Başlık": "Title",
    "Kategori": "Category",
    "Tutar": "Amount",
    "Tarih": "Date",
    "Birim": "Unit",
    "Birim Fiyat": "Unit Price",
    "Toplam Tutar": "Total Amount",
    "Stok Miktarı": "Stock Quantity",
    "Miktar": "Quantity",
    "Alım Tarihi": "Purchase Date",
    "Gelir Tarihi": "Income Date",
    "Gider Tarihi": "Expense Date",
    "Ödeme Tarihi": "Payment Date",
    "Çalışılan Gün": "Work Days",
    "Günlük Ücret": "Daily Wage",
    "Aktif mi?": "Active?",
    "İş Türü": "Work Type",
    "Görev": "Task",

    "Yeni Müşteri Ekle": "Add New Client",
    "Müşteri Ekle": "Add Client",
    "Müşteri Düzenle": "Edit Client",
    "Müşteri Sil": "Delete Client",
    "Müşteriler": "Clients",
    "İşveren ve müşteri kayıtları.": "Employer and client records.",
    "Yeni Proje": "New Project",
    "Proje Detayı": "Project Details",
    "Proje Düzenle": "Edit Project",
    "Proje Sil": "Delete Project",
    "Müşteri seçin": "Select a client",

    "Malzemeler": "Materials",
    "Malzeme": "Material",
    "Malzeme Adı": "Material Name",
    "Malzeme Türü": "Material Type",
    "Yeni Malzeme Ekle": "Add New Material",
    "Malzeme Ekle": "Add Material",
    "Malzeme Düzenle": "Edit Material",
    "Malzeme Detayı": "Material Details",
    "Malzeme Sil": "Delete Material",
    "Malzeme türü seçin": "Select a material type",
    "Yeni Malzeme Türü Ekle": "Add New Material Type",
    "Malzeme Türü Ekle": "Add Material Type",
    "Malzeme Türü Düzenle": "Edit Material Type",
    "Malzeme Türü Sil": "Delete Material Type",

    "Yeni Tedarikçi Ekle": "Add New Supplier",
    "Tedarikçi Ekle": "Add Supplier",
    "Tedarikçi Düzenle": "Edit Supplier",
    "Tedarikçi Sil": "Delete Supplier",
    "Tedarikçi": "Supplier",
    "Malzeme tedarikçi firmaları.": "Material supplier companies.",

    "Malzeme Alımları": "Material Purchases",
    "Yeni Malzeme Alımı": "New Material Purchase",
    "Malzeme Alımı": "Material Purchase",
    "Malzeme Alımı Detayı": "Material Purchase Details",
    "Malzeme seçin": "Select a material",
    "Tedarikçi seçin": "Select a supplier",
    "Proje bazlı malzeme alımları ve stok artışı.": "Project-based material purchases and stock increases.",

    "Taşeronlar": "Subcontractors",
    "Yeni Taşeron Ekle": "Add New Subcontractor",
    "Taşeron Ekle": "Add Subcontractor",
    "Taşeron Düzenle": "Edit Subcontractor",
    "Taşeron Sil": "Delete Subcontractor",
    "Demirci, kalıpçı, elektrikçi ve tesisatçı taşeron firmalar.": "Rebar, formwork, electrical and plumbing subcontractors.",

    "İşçiler": "Workers",
    "Yeni İşçi Ekle": "Add New Worker",
    "İşçi Ekle": "Add Worker",
    "İşçi Düzenle": "Edit Worker",
    "İşçi Sil": "Delete Worker",
    "İşçi": "Worker",
    "İnşaat işçileri ve günlük ücret bilgileri.": "Construction workers and daily wage information.",
    "İşçi Ödemeleri": "Worker Payments",
    "Yeni İşçi Ödemesi": "New Worker Payment",
    "İşçi Ödemesi": "Worker Payment",
    "İşçi Ödemesi Detayı": "Worker Payment Details",
    "İşçi seçin": "Select a worker",

    "Proje Gelirleri": "Project Incomes",
    "Yeni Proje Geliri": "New Project Income",
    "Proje Geliri": "Project Income",
    "Proje Geliri Detayı": "Project Income Details",
    "Hakediş ve proje gelir kayıtları.": "Progress payment and project income records.",
    "Giderler": "Expenses",
    "Yeni Gider Ekle": "Add New Expense",
    "Gider Ekle": "Add Expense",
    "Gider Düzenle": "Edit Expense",
    "Gider Sil": "Delete Expense",
    "Şantiye giderleri ve kategori takibi.": "Site expenses and category tracking.",

    "Sistem Girişi": "System Login",
    "İnşaat otomasyonu ve BuildTaskFlow ekranlarına rolünüze göre giriş yapın.": "Sign in to the construction automation and BuildTaskFlow screens according to your role.",
    "Örnek kullanıcılar": "Sample Users",
    "Tüm örnek kullanıcıların şifresi aynıdır:": "All sample users share the same password:",
    "Rol": "Role",
    "E-posta": "Email",
    "Şifre": "Password",
    "Beni hatırla": "Remember me",
    "Yetki Özeti": "Permission Summary",
    "Tüm ekranlara erişir.": "Can access all screens.",
    "Proje ve görev yönetir.": "Manages projects and tasks.",
    "Projeleri, işçileri ve saha görevlerini takip eder.": "Tracks projects, workers and site tasks.",
    "Malzeme, stok, tedarikçi ve görev takibi yapar.": "Tracks materials, stock, suppliers and tasks.",
    "Finans kayıtlarını ve fatura/proforma taslaklarını yönetir.": "Manages financial records and invoice/proforma drafts.",
    "Sadece görüntüleme yapar.": "Read-only access.",
    "Yetkisiz Erişim": "Access Denied",
    "Bu sayfayı görüntülemek için rolünüz yeterli değil.": "Your role is not allowed to view this page.",
    "BuildTaskFlow Dashboard": "BuildTaskFlow Dashboard",

    "İnşaat projesi görev yönetimi, rol takibi ve proforma/fatura taslakları.": "Construction project task management, role tracking and proforma/invoice drafts.",
    "Ekip": "Team",
    "Görevler": "Tasks",
    "Proje Sayısı": "Project Count",
    "Toplam Görev": "Total Tasks",
    "Devam Eden Görev": "Active Tasks",
    "Tamamlanan Görev": "Completed Tasks",
    "Geciken Görev": "Overdue Tasks",
    "Aktif Ekip Üyesi": "Active Team Members",
    "Taslak Proforma Toplamı": "Draft Proforma Total",
    "Giriş Yapan Rol": "Signed-in Role",
    "Yakın Görevler": "Upcoming Tasks",
    "Yeni Görev": "New Task",
    "Öncelik": "Priority",
    "Teslim": "Due",
    "Atanan": "Assigned To",
    "Atanan Ekip Üyesi": "Assigned Team Member",
    "Atama yok": "No assignment",
    "Teslim Tarihi": "Due Date",
    "Oluşturulma Tarihi": "Created Date",
    "Tamamlanma Tarihi": "Completion Date",
    "Görev Başlığı": "Task Title",
    "Görev Detayı": "Task Details",
    "Görev Düzenle": "Edit Task",
    "Görev Ekle": "Add Task",
    "Görev durumu, öncelik, teslim tarihi ve atanan ekip üyesi takibi.": "Track task status, priority, due date and assigned team member.",
    "Yorumlar": "Comments",
    "Yorum": "Comment",
    "Yorum Ekle": "Add Comment",
    "Yorum Kaydet": "Save Comment",
    "Henüz yorum eklenmemiş.": "No comments yet.",
    "Yorum Tarihi": "Comment Date",

    "BuildTaskFlow Projeleri": "BuildTaskFlow Projects",
    "BuildTaskFlow Projesi Düzenle": "Edit BuildTaskFlow Project",
    "Yeni BuildTaskFlow Projesi": "New BuildTaskFlow Project",
    "Proje planları, sorumlular ve görev durumu takibi.": "Project plans, owners and task status tracking.",
    "Sorumlu": "Owner",
    "Sorumlu seçin": "Select an owner",
    "Proje Sorumlusu": "Project Manager",
    "Projeye Bağlı Görevler": "Project Tasks",
    "Fatura/Proforma": "Invoice/Proforma",

    "Ekip Üyeleri ve Roller": "Team Members and Roles",
    "BuildTaskFlow giriş kullanıcıları ve rol bazlı yetki takibi.": "BuildTaskFlow login users and role-based permission tracking.",
    "Yeni Kullanıcı": "New User",
    "Kullanıcı Düzenle": "Edit User",
    "BuildTaskFlow Kullanıcı Ekle": "Add BuildTaskFlow User",
    "Rol seçin": "Select a role",
    "Kayıt Tarihi": "Registration Date",
    "Atanan Görev": "Assigned Task",

    "Proforma/Fatura Taslakları": "Proforma/Invoice Drafts",
    "Proforma/Fatura Taslağı": "Proforma/Invoice Draft",
    "Yeni Taslak": "New Draft",
    "Yeni Proforma/Fatura Taslağı": "New Proforma/Invoice Draft",
    "Bu ekran resmi fatura kesmez. Operasyon takibi için tarihli, numaralı ve kalemli taslak oluşturur.": "This screen does not issue official invoices. It creates dated, numbered and itemized drafts for operational tracking.",
    "Resmi fatura değildir": "Not an official invoice",
    "Resmi fatura değildir; operasyon takibi için tarihli, numaralı ve kalemli taslak kaydıdır.": "Not an official invoice; it is a dated, numbered and itemized draft record for operational tracking.",
    "Taslak Oluştur": "Create Draft",
    "No": "No",
    "Vade": "Due",
    "Vade Tarihi": "Due Date",
    "Fatura Tarihi": "Invoice Date",
    "Müşteri / Firma": "Client / Company",
    "İlgili Proje": "Related Project",
    "Kalem": "Line Item",
    "Kalem Açıklaması": "Line Description",
    "Ara Toplam": "Subtotal",
    "KDV Oranı (%)": "VAT Rate (%)",
    "KDV Tutarı": "VAT Amount",
    "KDV": "VAT",
    "Genel Toplam": "Grand Total",
    "Not": "Note",

    "SQL Sorgu Ekranı": "SQL Query Screen",
    "Güvenli, sadece okuma amaçlı SQL sorgu alanı.": "A safe, read-only SQL query area.",
    "Dashboard'a Dön": "Back to Dashboard",
    "Hazır Sorgular": "Sample Queries",
    "SQL Sorgusu": "SQL Query",
    "Sorguyu Çalıştır": "Run Query",
    "Bu ekranda sadece tek bir SELECT sorgusu çalıştırılır.": "Only a single SELECT query can be executed on this screen.",
    "Sorgu Sonucu": "Query Result",
    "En fazla 200 satır gösterilir.": "A maximum of 200 rows are displayed.",
    "Tüm projeler": "All projects",
    "Aktif projeler": "Active projects",
    "Malzemeler ve stok": "Materials and stock",
    "Projeye göre malzeme alımları": "Material purchases by project",
    "Projeye göre işçi ödemeleri": "Worker payments by project",
    "Projeye göre giderler": "Expenses by project",
    "Tedarikçiye göre toplam alım": "Total purchases by supplier",
    "Malzeme türüne göre stok": "Stock by material type",
    "Dashboard toplamları": "Dashboard totals",
    "Net kar/zarar": "Net profit/loss",

    "Yönetici": "Admin",
    "Şantiye Şefi": "Site Chief",
    "Depo / Malzeme Sorumlusu": "Material Manager",
    "Muhasebe": "Accounting",
    "Görüntüleyici": "Viewer",
    "Aktif": "Active",
    "Pasif": "Inactive",
    "Tamamlandı": "Completed",
    "Beklemede": "On Hold",
    "İptal": "Canceled",
    "Planlandı": "Planned",
    "Devam Ediyor": "In Progress",
    "Yapılacak": "To Do",
    "Test Ediliyor": "In Testing",
    "Taslak": "Draft",
    "Kesildi": "Issued",
    "Ödendi": "Paid",
    "Düşük": "Low",
    "Orta": "Medium",
    "Yüksek": "High",
    "Acil": "Urgent",
    "Yemek": "Meals",
    "Nakliye": "Transportation",
    "Yakıt": "Fuel",
    "Elektrik": "Electricity",
    "Su": "Water",
    "Kira": "Rent",
    "Bakım": "Maintenance",
    "Diğer": "Other",

    "Müşteri kaydı oluşturuldu.": "Client record created.",
    "Müşteri kaydı güncellendi.": "Client record updated.",
    "Müşteri kaydı silindi.": "Client record deleted.",
    "Proje kaydı oluşturuldu.": "Project record created.",
    "Proje kaydı güncellendi.": "Project record updated.",
    "Proje kaydı silindi.": "Project record deleted.",
    "Malzeme kaydı oluşturuldu.": "Material record created.",
    "Malzeme kaydı güncellendi.": "Material record updated.",
    "Malzeme kaydı silindi.": "Material record deleted.",
    "Malzeme Türü kaydı oluşturuldu.": "Material type record created.",
    "Malzeme Türü kaydı güncellendi.": "Material type record updated.",
    "Malzeme Türü kaydı silindi.": "Material type record deleted.",
    "Tedarikçi kaydı oluşturuldu.": "Supplier record created.",
    "Tedarikçi kaydı güncellendi.": "Supplier record updated.",
    "Tedarikçi kaydı silindi.": "Supplier record deleted.",
    "Taşeron kaydı oluşturuldu.": "Subcontractor record created.",
    "Taşeron kaydı güncellendi.": "Subcontractor record updated.",
    "Taşeron kaydı silindi.": "Subcontractor record deleted.",
    "İşçi kaydı oluşturuldu.": "Worker record created.",
    "İşçi kaydı güncellendi.": "Worker record updated.",
    "İşçi kaydı silindi.": "Worker record deleted.",
    "Gider kaydı oluşturuldu.": "Expense record created.",
    "Gider kaydı güncellendi.": "Expense record updated.",
    "Gider kaydı silindi.": "Expense record deleted.",
    "Malzeme alımı kaydedildi ve stok miktarı güncellendi.": "Material purchase saved and stock quantity updated.",
    "Proje geliri kaydedildi.": "Project income saved.",
    "İşçi ödemesi kaydedildi.": "Worker payment saved.",
    "BuildTaskFlow oturumu kapatıldı.": "BuildTaskFlow session closed.",
    "BuildTaskFlow projesi oluşturuldu.": "BuildTaskFlow project created.",
    "BuildTaskFlow projesi güncellendi.": "BuildTaskFlow project updated.",
    "Görev oluşturuldu.": "Task created.",
    "Görev güncellendi.": "Task updated.",
    "Yorum eklendi.": "Comment added.",
    "BuildTaskFlow kullanıcısı oluşturuldu.": "BuildTaskFlow user created.",
    "BuildTaskFlow kullanıcısı güncellendi.": "BuildTaskFlow user updated.",
    "Proforma/fatura taslağı oluşturuldu.": "Proforma/invoice draft created.",
    "Bu kayıt ilişkili veriler bulunduğu için silinemedi.": "This record could not be deleted because related data exists.",
    "Bu malzeme ilişkili alım kaydı bulunduğu için silinemedi.": "This material could not be deleted because related purchase records exist.",
    "Bu proje ilişkili gelir, gider, malzeme alımı veya işçi ödemesi bulunduğu için silinemedi.": "This project could not be deleted because related income, expense, material purchase or worker payment records exist.",
    "E-posta veya şifre hatalı.": "Email or password is incorrect.",
    "Bu e-posta ile kayıtlı bir kullanıcı var.": "A user with this email already exists.",
    "Bu e-posta ile kayıtlı başka bir kullanıcı var.": "Another user with this email already exists.",
    "Bu numara ile kayıtlı bir taslak var.": "A draft with this number already exists.",
    "Geçerli bir proje seçin.": "Select a valid project.",
    "Geçerli bir müşteri seçin.": "Select a valid client.",
    "Geçerli bir malzeme seçin.": "Select a valid material.",
    "Geçerli bir malzeme türü seçin.": "Select a valid material type.",
    "Geçerli bir tedarikçi seçin.": "Select a valid supplier.",
    "Geçerli bir işçi seçin.": "Select a valid worker.",
    "Geçerli bir kategori seçin.": "Select a valid category.",
    "Geçerli bir rol seçin.": "Select a valid role.",
    "Geçerli bir durum seçin.": "Select a valid status.",
    "Geçerli bir ekip üyesi seçin.": "Select a valid team member.",
    "Geçerli bir proje sorumlusu seçin.": "Select a valid project manager.",
    "Yorum eklemek için geçerli bir BuildTaskFlow kullanıcısı gerekir.": "A valid BuildTaskFlow user is required to add a comment.",
    "Bu ekranda sadece tek bir SELECT sorgusu çalıştırılabilir. INSERT, UPDATE, DELETE, DROP gibi komutlara izin verilmez.": "Only a single SELECT query can be executed on this screen. INSERT, UPDATE, DELETE, DROP and similar commands are not allowed."
  };

  const phraseMap = {
    "İnşaat Şirketi Şantiye ve Malzeme Yönetim Sistemi": "Construction Company Site and Material Management System",
    "İnşaat Şantiye Yönetimi": "Construction Site Management",
    "Şantiye Yönetimi": "Site Management",
    "Sistem Girişi": "System Login",
    "Depo / Malzeme Sorumlusu": "Material Manager",
    "Proje Sorumlusu": "Project Manager",
    "Şantiye Şefi": "Site Chief",
    "Görüntüleyici": "Viewer",
    "Yönetici": "Admin",
    "Muhasebe": "Accounting",
    "Devam Ediyor": "In Progress",
    "Test Ediliyor": "In Testing",
    "Tamamlandı": "Completed",
    "Beklemede": "On Hold",
    "Planlandı": "Planned",
    "Yapılacak": "To Do",
    "Kesildi": "Issued",
    "Ödendi": "Paid",
    "Taslak": "Draft",
    "İptal": "Canceled",
    "Aktif": "Active",
    "Pasif": "Inactive",
    "Düşük": "Low",
    "Orta": "Medium",
    "Yüksek": "High",
    "Acil": "Urgent",
    "Yemek": "Meals",
    "Nakliye": "Transportation",
    "Yakıt": "Fuel",
    "Elektrik": "Electricity",
    "Su": "Water",
    "Kira": "Rent",
    "Bakım": "Maintenance",
    "Diğer": "Other",
    "tamamlandı": "completed"
  };

  const skipTags = new Set(["SCRIPT", "STYLE", "TEXTAREA", "CODE", "PRE", "NOSCRIPT"]);
  let translating = false;

  function translateText(text) {
    if (!text || !text.trim()) {
      return text;
    }

    const leading = text.match(/^\s*/)[0];
    const trailing = text.match(/\s*$/)[0];
    const core = text.trim();

    if (exact[core]) {
      return leading + exact[core] + trailing;
    }

    let translated = core
      .replace(/(\d+)\s+satır listelendi\./g, "$1 rows listed.")
      .replace(/Fatura Tarihi:\s*/g, "Invoice Date: ")
      .replace(/Vade Tarihi:\s*/g, "Due Date: ")
      .replace(/Durum:\s*/g, "Status: ");

    for (const [source, target] of Object.entries(phraseMap).sort((a, b) => b[0].length - a[0].length)) {
      translated = translated.split(source).join(target);
    }

    return leading + translated + trailing;
  }

  function shouldSkip(node) {
    const parent = node.parentElement;
    if (!parent) {
      return true;
    }

    return parent.closest(Array.from(skipTags).join(","));
  }

  function translateNode(node) {
    if (node.nodeType === Node.TEXT_NODE) {
      if (!shouldSkip(node)) {
        const next = translateText(node.nodeValue);
        if (next !== node.nodeValue) {
          node.nodeValue = next;
        }
      }
      return;
    }

    if (node.nodeType !== Node.ELEMENT_NODE || skipTags.has(node.tagName)) {
      return;
    }

    for (const attr of ["title", "placeholder", "aria-label", "value"]) {
      if (node.hasAttribute(attr)) {
        const value = node.getAttribute(attr);
        const next = translateText(value);
        if (next !== value) {
          node.setAttribute(attr, next);
        }
      }
    }

    for (const child of node.childNodes) {
      translateNode(child);
    }
  }

  function translatePage() {
    if (translating) {
      return;
    }

    translating = true;
    const nextTitle = translateText(document.title);
    if (nextTitle !== document.title) {
      document.title = nextTitle;
    }

    translateNode(document.body);
    translating = false;
  }

  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", translatePage);
  } else {
    translatePage();
  }
})();
