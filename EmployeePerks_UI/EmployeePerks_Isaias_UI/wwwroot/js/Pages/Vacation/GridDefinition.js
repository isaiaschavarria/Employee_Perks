const gridDefinition = [
    { field: "startDay", headerName: "Inicio", valueFormatter: formatToDate },
    { field:"endDay", headerName: "Fin" },
    { field:"justification", headerName: "Justificacion" }
];

let gridApi;

const gridOptions = {
    columnDefs: gridDefinition,
    rowData: [],
    rowSelection: {
        mode: 'singleRow'
    },
    defaultColDef: {sortable: true, filter: true}
}

function formatToDate(params) {
    let date = new Date(params.value);

    if (isNaN(date)) {
        throw new Error("Invalid date value");
    }

    let day = String(date.getDate()).padStart(2, '0');
    let month = String(date.getMonth() + 1).padStart(2, '0'); // Months are 0-based
    let year = date.getFullYear();

    return `${day}/${month}/${year}`;
}

document.addEventListener('DOMContentLoaded', () => {
    const div = document.querySelector('#myGrid');
    gridApi = agGrid.createGrid(div, gridOptions);
})