import axios from "axios";

export const getChores = async () => {
    try {
        // Retrieve the token from localStorage
        const user = JSON.parse(localStorage.getItem("user"));
        const token = user?.token;  // Check if the token exists in the user object
        
        if (!token) {
            throw new Error("No token found");
        }
        
        const response = await axios.get("http://localhost:5081/api/chores", {
            headers: {
                Authorization: `Bearer ${token}`,  // Send token in headers for authentication
            },
        });
        return response.data;
    } catch (error) {
        console.error("Error fetching chores:", error);
        return [];
    }
};
