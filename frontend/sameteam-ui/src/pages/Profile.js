import React, { useEffect, useState } from "react";
import { getToken } from "../services/authService";

const Profile = () => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        const token = getToken();
        if (token) {
            const decodedToken = JSON.parse(atob(token.split('.')[1])); // Decode the JWT to extract user info
            setUser(decodedToken);
        }
    }, []);

    return (
        <div>
            <h1>Profile</h1>
            {user ? (
                <div>
                    <p><strong>Name:</strong> {user.sub}</p>
                    <p><strong>User ID:</strong> {user.userID}</p>
                    <p><strong>Role:</strong> {user.role}</p>
                </div>
            ) : (
                <p>Please log in to see your profile.</p>
            )}
        </div>
    );
};

export default Profile;
