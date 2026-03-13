
// DOM Ready
document.addEventListener("DOMContentLoaded", function () {

    //  General Click Header
    const trackableElements = document.querySelectorAll('[data-header="click_content"]');
    trackableElements.forEach(function (element) {
        element.addEventListener("click", function () {
            const eventData = {
                event: element.dataset.header,
                location: element.dataset.location || "",
                type: element.dataset.type || "",
                title: element.dataset.title || "",
                name: element.dataset.name || "",
            };
            window.dataLayer.push(eventData);
        });
    });

    //  General Click Tracking
    document.addEventListener("click", function (event) {
        //faq items
        if (this.activeElement != null && $(this.activeElement).hasClass('gtm_click_event')) {
            var currentCount = $(this.activeElement).attr('data-count');
            var newCount = currentCount === '1' ? '0' : '1';

            $(this.activeElement).attr('data-count', newCount);
            var faq_item = $(this.activeElement);

            // Only track when expanding (opening) the accordion
            if (newCount === '0') {
                window.dataLayer.push({
                    event: faq_item.data('faq') || '',
                    location: faq_item.data('location') || '',
                    type: faq_item.data('type') || '',
                    title: faq_item.data('title') || '',
                    name: faq_item.data('name') || ''
                });
            }
        }

        const element = event.target.closest('[data-event="click_content"]');
        if (element) {
            const eventData = {
                event: element.dataset.event,
                location: element.dataset.location || "",
                type: element.dataset.type || "",
                title: element.dataset.title || "",
                name: element.dataset.name || "",
            };
            window.dataLayer.push(eventData);
        }
    });
 
    //  Cost Calculator Event
    const calculateButtons = document.querySelectorAll('.js-calculate-btn');
    function getCostCalculatorEventData() {
        return {
            event: "cost_calculator",
            career_interest: document.getElementById("careerInterest")?.selectedOptions[0]?.text || '',
            programme_level: document.getElementById("levelOfStudy")?.selectedOptions[0]?.text || '',
            programme_name: document.getElementById("programmeEnrolling")?.selectedOptions[0]?.text || '',
           // type_of_study: document.getElementById("enrollmentType")?.selectedOptions[0]?.text || '',
            mode_of_study: document.getElementById("modeOfStudy")?.selectedOptions[0]?.text || '',
            //residency_status: document.getElementById("uae-residency-status")?.selectedOptions[0]?.text || '',
        };
    }
    calculateButtons.forEach(button => {
        button.addEventListener("click", function () {
            const costEventData = getCostCalculatorEventData();
            window.dataLayer.push(costEventData);
        });
    });

    //  Application Form Event
    const applicationForm = document.getElementById('application-form');
    if (applicationForm) {
        applicationForm.addEventListener('submit', function (e) {
            
            const applicationEventData = getApplicationFormEventData();
            if (applicationEventData != null) {
                window.dataLayer.push(applicationEventData);
            }
        });
    }

    function getApplicationFormEventData() {
        // Get Programme Level (checkboxes)
        const programmeLevelCheckboxes = document.querySelectorAll('.application-programme-level input[type="checkbox"]:checked');
        const programmeLevels = Array.from(programmeLevelCheckboxes).map(cb => {
            return cb.closest('label').querySelector('span:last-child').textContent.trim();
        });

        // Get Selected Programme (dropdown)
        const programmeSelect = document.querySelector('select[name="programme"]');
        const selectedProgramme = programmeSelect?.selectedOptions[0]?.text || '';

        // Get Delivery Method (checkboxes)
        //const deliveryMethodCheckboxes = document.querySelectorAll('.application-delivery-method input[type="checkbox"]:checked');
        //const deliveryMethods = Array.from(deliveryMethodCheckboxes).map(cb => {
        //    return cb.closest('label').querySelector('span:last-child').textContent.trim();
        //});

        // Get Mode of Study (checkboxes)
        const modeOfStudyCheckboxes = document.querySelectorAll('.application-mode-of-study input[type="checkbox"]:checked');
        const modesOfStudy = Array.from(modeOfStudyCheckboxes).map(cb => {
            return cb.closest('label').querySelector('span:last-child').textContent.trim();
        });

        // Get Starting Date (dropdown)
        const startingDateSelect = document.querySelector('select[name="startingDate"]');
        const selectedStartingDate = startingDateSelect?.selectedOptions[0]?.text || '';

        // Get Terms & Conditions acceptance
        const termsCheckbox = document.querySelector('input[name="terms"]');
        const termsAccepted = termsCheckbox?.checked ? 'yes' : 'no';

        if (programmeLevels == '' || selectedProgramme == '' || modesOfStudy == '' || selectedStartingDate == '' || termsAccepted === 'no') {
            return null;    
        }

        return {
            event: "apply_now",
            programme_level: programmeLevels.join(', ') ,
            programme_name: selectedProgramme,
           // delivery_method: deliveryMethods.join(', ') ,
            mode_of_study: modesOfStudy.join(', ') ,
            starting_date: selectedStartingDate,
          //  terms_accepted: termsAccepted,
          //  language_code: "EN"
        };
    }

    //  Search Event Tracking
    const searchForm = document.getElementById('searchForm');
    const searchInput = document.getElementById('textInput');

    if (searchForm && searchInput) {
        // Track search on Enter key press
        searchInput.addEventListener('keypress', function (e) {
            if (e.key === 'Enter') {
                const searchTerm = searchInput.value.trim();
                if (searchTerm) {
                    const searchEventData = {
                        event: "search",
                        search_term: searchTerm
                    };
                    window.dataLayer.push(searchEventData);
                }
            }
        });

        // Optional: Track search when user clicks on suggested items
        const topSearchList = document.getElementById('topSearchList');
        const suggestedList = document.getElementById('SuggestedList');

        // Track top search clicks
        if (topSearchList) {
            topSearchList.addEventListener('click', function (e) {
                if (e.target.tagName === 'A' || e.target.closest('a')) {
                    const clickedItem = e.target.tagName === 'A' ? e.target : e.target.closest('a');
                    const searchTerm = clickedItem.textContent.trim();
                    if (searchTerm) {
                        const searchEventData = {
                            event: "search",
                            search_term: searchTerm
                        };
                        window.dataLayer.push(searchEventData);
                    }
                }
            });
        }
    }



});

// GTM Helper Functions
function pushFilterSelectionToGTM(filterGroupText, selectedFilterTexts) {
    if (typeof gtag !== 'undefined') {
        gtag('event', 'click_content', {
            'type': 'Filter',
            'location': 'Page Body',
            'name': selectedFilterTexts.join(' | '),
            'title': filterGroupText,
        });
    }

    // Alternative DataLayer push if gtag is not available
    if (typeof dataLayer !== 'undefined') {
        dataLayer.push({
            'event': 'click_content',
            'type': 'Filter',
            'location': 'Page Body',
            'name': selectedFilterTexts.join(' : '),
            'title': filterGroupText,
        });
    }
}
function pushFilterClearToGTM(clearedFilters) {
  //  const filterNames = clearedFilters.map(filter => filter.texts.join(' : ')).join(', ');
  
    if (typeof dataLayer !== 'undefined') {
        dataLayer.push({
            'event': 'click_content',
            'Location': 'Page Body',
            'type': 'Filter',
            'name': clearedFilters,
            'title': 'Filter clearance',
        });
    }
}
function pushClearButtonToGTM() {
    dataLayer.push({
        'Location': 'Page Body',
        'type': 'Filter',
        'event': 'click_content',
        'name': "Clear",
        'title': 'Filter clearance',
    });
    
}