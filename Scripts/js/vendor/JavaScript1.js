// script.js
document.addEventListener('DOMContentLoaded', function () {
    const slider = document.getElementById('slider');

    const sliderItems = [
        {
            id:1,
            bg: "whi",
            img: "https://theme.hstatic.net/1000006063/1000748098/14/home_slider_17_d_master.jpg?v=13914",
            title: "Serum Garnier Light Complete ",
            description: "Tinh Chất Tăng Cường Sáng Da Mờ Thâm Garnier Light Complete Vitamin C 30X Booster Serum .",
            button:"/Home/Facialcare"
        },
        {
            id:2,
            bg: "whi",
            img: "https://theme.hstatic.net/1000006063/1000748098/14/home_slider_2_d_master.jpg?v=13914",
            title: "Bút Gel Romand Twinkle Pen Liner",
            description: "Bút Nhũ Mắt Dạng Gel, Kẻ Bọng Mắt Ánh Nhũ Lấp Lánh, Lâu Trôi Romand Twinkle Pen Liner ",
            button: "/Home/Makeup"

        },
        
    ];

    let slideIndex = 0;

    function renderSlider() {
        const container = document.createElement('div'); 
        container.classList.add('containersss');

        const leftArrow = document.createElement('div');
        leftArrow.classList.add('arrows', 'lefts');
        leftArrow.innerHTML = `<i class="fa fa-chevron-left"></i>`;

        const rightArrow = document.createElement('div');
        rightArrow.classList.add('arrows', 'rights');
        rightArrow.innerHTML = `<i class="fa fa-chevron-right"></i>`;

        const wrapper = document.createElement('div');
        wrapper.classList.add('wrappers');

        // Add your slider items to the wrapper
        sliderItems.forEach((item, index) => {
            const slide = document.createElement('div');
            slide.classList.add('slides');
            slide.style.backgroundColor = `#${item.bg}`;

            const imgContainer = document.createElement('div');
            imgContainer.classList.add('img-containers');

            const image = document.createElement('img');
            image.classList.add('images');
            image.src = item.img;

            const infoContainer = document.createElement('div');
            infoContainer.classList.add('info-containers');

            const title = document.createElement('h1');
            title.classList.add('titles');
            title.textContent = item.title;

            const description = document.createElement('p');
            description.classList.add('descriptions');
            description.textContent = item.description;
            const button = document.createElement('button');
            button.classList.add('buttons'); // Thêm lớp CSS nếu cần
            button.textContent = "Click here"; // Thêm văn bản cho nút

            button.addEventListener('click', function () {
                window.location.href = item.button; // Chuyển hướng đến URL từ item.button
            });


            infoContainer.appendChild(title);
            infoContainer.appendChild(description);
            infoContainer.appendChild(button);

            imgContainer.appendChild(image);

            slide.appendChild(imgContainer);
            slide.appendChild(infoContainer);

            wrapper.appendChild(slide);
        });

        container.appendChild(leftArrow);
        container.appendChild(wrapper);
        container.appendChild(rightArrow);

        slider.appendChild(container);

        // Add click event listeners for left and right arrows
        leftArrow.addEventListener('click', () => {
            slideIndex = slideIndex > 0 ? slideIndex - 1 : sliderItems.length - 1;
            updateSlider();
        });

        rightArrow.addEventListener('click', () => {
            slideIndex = slideIndex < sliderItems.length - 1 ? slideIndex + 1 : 0;
            updateSlider();
        });

        // Function to update slider position
        function updateSlider() {
            wrapper.style.transform = `translateX(${slideIndex * -100}vw)`;
        }
    }

    renderSlider();
});