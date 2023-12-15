// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const cards = document.querySelectorAll('.card');

// Iterate through each card
cards.forEach(card => {
    // Find the edit button inside the card
    const editButton = card.querySelector('#edit');

    // Initially hide the edit button
    editButton.classList.add('d-none');

    // Show the edit button when hovering over the card
    card.addEventListener('mouseover', () => {
        editButton.classList.add('d-block');
        editButton.classList.remove('d-none');
    });

    // Hide the edit button when not hovering over the card
    card.addEventListener('mouseout', () => {
        editButton.classList.add('d-none');
        editButton.classList.remove('d-block');
    });
});