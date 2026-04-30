
(function() {
    const styleSheet = document.createElement('style');
    styleSheet.textContent = `
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            background: #e5e7eb;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
            padding: 20px;
        }

        .card {
            width: 100%;
            max-width: 420px;
            background: white;
            border-radius: 20px;
            overflow: hidden;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s;
        }

        .card:hover {
            transform: translateY(-2px);
        }

        .image-container {
            position: relative;
        }

        .house-image {
            width: 100%;
            height: 240px;
            object-fit: cover;
            display: block;
        }

        .heart {
            position: absolute;
            top: 16px;
            right: 16px;
            font-size: 32px;
            cursor: pointer;
            background: rgba(255, 255, 255, 0.85);
            width: 48px;
            height: 48px;
            border-radius: 50%;
            display: flex;
            align-items: center;
            justify-content: center;
            transition: all 0.2s ease;
            backdrop-filter: blur(2px);
            box-shadow: 0 2px 8px rgba(0, 0, 0, 0.15);
            user-select: none;
        }

        .heart:hover {
            transform: scale(1.05);
            background: white;
        }

        .content {
            padding: 20px;
        }

        .info-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 12px;
            flex-wrap: wrap;
        }

        .tag {
            background: #f3f4f6;
            padding: 4px 12px;
            border-radius: 30px;
            font-size: 13px;
            font-weight: 600;
            color: #1f2937;
        }

        .age {
            background: #fef9c3;
            color: #854d0e;
            font-size: 12px;
            font-weight: 500;
            padding: 4px 10px;
            border-radius: 30px;
        }

        .price {
            font-size: 28px;
            font-weight: 700;
            color: #111827;
            margin-bottom: 12px;
        }

        .price span {
            font-size: 20px;
            font-weight: 600;
        }

        .address {
            font-size: 18px;
            font-weight: 600;
            color: #374151;
            margin-bottom: 16px;
            padding-bottom: 8px;
            border-bottom: 1px solid #e5e7eb;
        }

        .features {
            display: flex;
            gap: 24px;
            margin-bottom: 20px;
        }

        .feature {
            display: flex;
            align-items: center;
            gap: 8px;
            font-size: 15px;
            font-weight: 500;
            color: #4b5563;
        }

        .feature-icon {
            font-size: 20px;
        }

        .realtor-section {
            display: flex;
            align-items: center;
            justify-content: space-between;
            background: #f9fafb;
            padding: 12px 16px;
            border-radius: 50px;
            margin-top: 8px;
        }

        .realtor-left {
            display: flex;
            align-items: center;
            gap: 12px;
        }

        .profile-photo {
            width: 44px;
            height: 44px;
            border-radius: 50%;
            object-fit: cover;
            background: #d1d5db;
            border: 2px solid white;
            box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);
        }

        .realtor-details {
            display: flex;
            flex-direction: column;
        }

        .realtor-label {
            font-size: 11px;
            color: #6b7280;
            text-transform: uppercase;
            letter-spacing: 0.5px;
        }

        .realtor-name {
            font-weight: 700;
            font-size: 15px;
            color: #1f2937;
            cursor: pointer;
        }

        .realtor-name:hover {
            color: #f97316;
        }

        .phone {
            font-size: 14px;
            font-weight: 500;
            color: #3b82f6;
            background: white;
            padding: 6px 12px;
            border-radius: 40px;
            cursor: pointer;
            transition: background 0.2s;
        }

        .phone:hover {
            background: #eff6ff;
        }

        .message {
            margin-top: 12px;
            font-size: 12px;
            text-align: center;
            padding: 8px;
            background: #f3f4f6;
            border-radius: 40px;
            color: #4b5563;
            transition: all 0.2s;
        }

        button {
            background: none;
            border: none;
        }

        .house-image {
            cursor: pointer;
        }
    `;
    document.head.appendChild(styleSheet);

    document.addEventListener('DOMContentLoaded', function() {
        
        const heartIcon = document.getElementById('heartBtn');
        const phoneElement = document.getElementById('phoneBtn');
        const feedbackDiv = document.getElementById('feedbackMsg');
        const houseImg = document.getElementById('houseImage');
        const realtorPhoto = document.getElementById('realtorPhoto');
        const realtorName = document.querySelector('.realtor-name');
        
        let isLiked = false;

        houseImg.src = 'house.jpg';
        
        realtorPhoto.src = 'https://randomuser.me/api/portraits/women/68.jpg';
        
        houseImg.onerror = function() {
            this.src = 'https://placehold.co/600x400/cbd5e1/334155?text=House+Image';
        };
        
        realtorPhoto.onerror = function() {
            this.src = 'https://placehold.co/100x100/f3f4f6/6b7280?text=👤';
        };
        
        let feedbackTimeout = null;
        
        function setFeedbackMessage(msg, isTemporary = true) {
            if (feedbackTimeout) clearTimeout(feedbackTimeout);
            feedbackDiv.innerHTML = msg;
            
            if (isTemporary) {
                feedbackTimeout = setTimeout(() => {
                    if (feedbackDiv.innerHTML === msg) {
                        feedbackDiv.innerHTML = '❤️ Click heart to save | 📞 Click phone to copy';
                    }
                }, 2500);
            }
        }
        
        function updateHeart() {
            if (isLiked) {
                heartIcon.innerHTML = '❤️';
                heartIcon.style.color = '#e11d48';
                heartIcon.style.background = 'rgba(255,255,240,0.95)';
                setFeedbackMessage('❤️ Saved to favorites! 742 Evergreen Terrace added.');
            } else {
                heartIcon.innerHTML = '♡';
                heartIcon.style.color = '';
                heartIcon.style.background = 'rgba(255,255,255,0.85)';
                setFeedbackMessage('♡ Removed from favorites.');
            }
        }
        
        if (heartIcon) {
            heartIcon.addEventListener('click', function(e) {
                e.stopPropagation();
                isLiked = !isLiked;
                updateHeart();
            });
        }
        
        if (phoneElement) {
            phoneElement.addEventListener('click', function(e) {
                e.stopPropagation();
                const phoneNumber = '(555) 555-4321';
                
                navigator.clipboard.writeText(phoneNumber).then(() => {
                    setFeedbackMessage('📞 Phone number copied: (555) 555-4321');
                    phoneElement.style.background = '#dbeafe';
                    setTimeout(() => {
                        phoneElement.style.background = '';
                    }, 500);
                }).catch(() => {
                    setFeedbackMessage('⚠️ Press and hold to copy manually: (555) 555-4321');
                });
            });
        }
        
        if (realtorName) {
            realtorName.addEventListener('click', function(e) {
                e.stopPropagation();
                setFeedbackMessage('🏠 Contact Tiffany Heffner: tiffany.heffner@realestate.com');
            });
        }
        
        if (houseImg) {
            houseImg.addEventListener('click', function() {
                setFeedbackMessage('🏡 742 Evergreen Terrace - Beautiful detached home! Schedule a viewing.');
            });
        }
        
        console.log('✅ Property card ready | All styles injected by script.js');
        console.log('💡 Tip: To use your house.jpg, edit line 148 in script.js');
    });
})();