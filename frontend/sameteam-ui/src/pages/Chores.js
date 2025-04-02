import React, { useEffect, useState } from "react";
import { getChores } from "../services/choresService";

const Chores = () => {
    const [chores, setChores] = useState([]);

    useEffect(() => {
        const fetchChores = async () => {
            const choresData = await getChores();
            setChores(choresData);
        };

        fetchChores();
    }, []);

    return (
        <div>
            <h1>Chores List</h1>
            <ul>
                {chores.length > 0 ? (
                    chores.map((chore) => (
                        <li key={chore.choreID}>
                            <h3>{chore.choreName}</h3>
                            <p>{chore.description}</p>
                            <p>Due Date: {new Date(chore.dueDate).toLocaleString()}</p>
                            <p>Status: {chore.isCompleted ? "Completed" : "Pending"}</p>
                        </li>
                    ))
                ) : (
                    <p>No chores found</p>
                )}
            </ul>
        </div>
    );
};

export default Chores;
