class DataTables {
  constructor(dataOrigin, context) {
    this.dataOrigin = dataOrigin;
    this.context = context;
  }

  fillContext() {
    fetch(this.dataOrigin)
      .then(response => {
        return response.json();
      })
      .then(data => {
        let htmlContent = '';
        let row = '';
        htmlContent +=
        `<table id="table_id" class = "display">
          <thead>
          <tr>
            <th>Id</th>
            <th>Quantity</th>
            <th>Name</th>
            <th>Price</th>
          </tr>
          </thead>
          <tbody>
        `
        for (const object of data) {
          htmlContent += "<tr>"
          for (const key in object) {
            row += `<td> ${object[key]} </td >`
          }
          htmlContent += `${row}`;
          row = '';
          htmlContent += "</tr>"
        }
        
        htmlContent += "</tbody>";
        htmlContent += "</table>";
        
        this.context.innerHTML = htmlContent;
        $(document).ready(function () {
          $.noConflict();
          $('#table_id').DataTable();
        });
      })
      .catch(error => {
        console.log(error);
      })
  }
}