window.generateCertificate = async function (nome) {
    const {jsPDF} = window.jspdf;
    const doc = new jsPDF({
        orientation: 'landscape',
        unit: "mm",
        format: "a4"
    });

    const img = new Image();
    img.src = "assets/ProautoKimium.jpg";

    await new Promise(resolve => img.onload = resolve);

    doc.addImage(img, "JPEG", 0, 0, 297, 210);
    doc.setFontSize(24);
    doc.setTextColor(0, 0, 0);
    doc.text(nome, 148, 85, {align: 'center'});

    doc.save(`certificado - ${nome}.pdf`);
}